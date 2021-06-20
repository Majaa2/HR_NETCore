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
    public class EmployeeRoleService : BaseCRUDService<Model.EmployeeRole, object, Database.EmployeeRole, EmployeeRoleUpsertRequest, EmployeeRoleUpsertRequest>
    {
        public EmployeeRoleService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeRoles.Include(x => x.Employee).Include(x => x.Role).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeRole>>(list);
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
                var query = _context.EmployeeRoles.Include(x => x.Employee).Include(x => x.Role).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeRole>(query);
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
            Model.EmployeeRole employeeRole = new Model.EmployeeRole();
            try
            {
                employeeRole = GetById(id).Result;
                employeeRole.Deleted = true;
                employeeRole.Active = false;
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

                response.Result = Update(employeeRole.Id, _mapper.Map<EmployeeRoleUpsertRequest>(employeeRole));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
