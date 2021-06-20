using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class WorkService : BaseCRUDService<Model.Work, object, Database.Work, WorkUpsertRequest, WorkUpsertRequest>
    {
        public WorkService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override HRResponse Get(object search)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var list = _context.Works.AsQueryable().Where(w => w.Active == true).ToList();
                var employeeWorks = _context.Employees.AsQueryable().Where(w => w.Active == true);
                foreach (var work in list)
                {
                    work.Number = employeeWorks.Where(x => x.WorkId == work.Id).ToList().Count();
                }
                response.Result = _mapper.Map<List<Work>>(list);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dobavljanja radnih mjesta",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Work work = new Model.Work();
            try
            {
                work = GetById(id).Result;
                work.Deleted = true;
                work.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja!",
                    ErrorList = new List<ResponseError>
                        {
                            new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                        }
                };
            }
            finally
            {

                response.Result = Update(work.Id, _mapper.Map<WorkUpsertRequest>(work));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
