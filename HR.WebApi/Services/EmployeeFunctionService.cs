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
    public class EmployeeFunctionService : BaseCRUDService<Model.EmployeeFunction, object, Database.EmployeeFunction, EmployeeFunctionUpsertRequest, EmployeeFunctionUpsertRequest>
    {
        public EmployeeFunctionService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeFunctions.Include(x => x.Employee).Include(x => x.Function).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeFunction>>(list);
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
                var query = _context.EmployeeFunctions.Include(x => x.Employee).Include(x => x.Function).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeFunction>(query);
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
            Model.EmployeeFunction employeeFunction = new Model.EmployeeFunction();
            try
            {
                employeeFunction = GetById(id).Result;
                employeeFunction.Deleted = true;
                employeeFunction.Active = false;
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

                response.Result = Update(employeeFunction.Id, _mapper.Map<EmployeeFunctionUpsertRequest>(employeeFunction));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
