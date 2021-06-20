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
    public class DepartmentService : BaseCRUDService<Model.Department, object, Database.Department, DepartmentUpsertRequest, DepartmentUpsertRequest>
    {
        public DepartmentService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var list = _context.Departments.AsQueryable().Where(e => e.Active == true).ToList();
                var employeeDepartments = _context.EmployeeDepartments.AsQueryable();
                foreach(var dept in list)
                {
                    dept.Number = employeeDepartments.Where(x => x.DepartmentId == dept.Id).ToList().Count();
                }
                response.Result = _mapper.Map<List<Department>>(list);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dobavljanja odjeljenja",
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
            Model.Department department = new Model.Department();
            try
            {
                department = GetById(id).Result;
                department.Deleted = true;
                department.Active = false;
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

                response.Result = Update(department.Id, _mapper.Map<DepartmentUpsertRequest>(department));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
