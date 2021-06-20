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
    public class EmployeeDepartmentService : BaseCRUDService<Model.EmployeeDepartment, object, Database.EmployeeDepartment, EmployeeDepartmentUpsertRequest, EmployeeDepartmentUpsertRequest>
    {
        public EmployeeDepartmentService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeDepartments.Include(x => x.Employee).Include(x => x.Department).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeDepartment>>(list);
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
                var query = _context.EmployeeDepartments.Include(x => x.Employee).Include(x => x.Department).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeDepartment>(query);
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
            Model.EmployeeDepartment employeeDepartment = new Model.EmployeeDepartment();
            try
            {
                employeeDepartment = GetById(id).Result;
                employeeDepartment.Deleted = true;
                employeeDepartment.Active = false;
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

                response.Result = Update(employeeDepartment.Id, _mapper.Map<EmployeeDepartmentUpsertRequest>(employeeDepartment));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
