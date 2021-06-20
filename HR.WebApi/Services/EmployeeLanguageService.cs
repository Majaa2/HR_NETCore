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
    public class EmployeeLanguageService : BaseCRUDService<Model.EmployeeLanguage, object, Database.EmployeeLanguage, EmployeeLanguageUpsertRequest, EmployeeLanguageUpsertRequest>
    {
        public EmployeeLanguageService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeLanguages.Include(x => x.Employee).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeLanguage>>(list);
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
                var query = _context.EmployeeLanguages.Include(x => x.Employee).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeLanguage>(query);
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
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.EmployeeLanguage employeeLanguage = new Model.EmployeeLanguage();
            try
            {
                employeeLanguage = GetById(id).Result;
                employeeLanguage.Deleted = true;
                employeeLanguage.Active = false;
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

                response.Result = Update(employeeLanguage.Id, _mapper.Map<EmployeeLanguageUpsertRequest>(employeeLanguage));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
