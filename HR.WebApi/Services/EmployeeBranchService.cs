using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using Microsoft.EntityFrameworkCore;using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class EmployeeBranchService : BaseCRUDService<Model.EmployeeBranch, object, Database.EmployeeBranch, EmployeeBranchUpsertRequest, EmployeeBranchUpsertRequest>
    {
        public EmployeeBranchService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeBranches.Include(x => x.Employee).Include(x => x.Branch).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeBranch>>(list);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public override HRResponse GetById(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.EmployeeBranches.Include(x => x.Employee).Include(x => x.Branch).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeBranch>(query);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.EmployeeBranch employeeBranch = new Model.EmployeeBranch();
            try
            {
                employeeBranch = GetById(id).Result;
                employeeBranch.Deleted = true;
                employeeBranch.Active = false;
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

                response.Result = Update(employeeBranch.Id, _mapper.Map<EmployeeBranchUpsertRequest>(employeeBranch));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
