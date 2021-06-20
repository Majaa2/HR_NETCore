using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Model.Requests;
using HR.WebApi.Interface;
using HR.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    public class EmployeeFunctionController : BaseCRUDController<Model.EmployeeFunction, object, EmployeeFunctionUpsertRequest, EmployeeFunctionUpsertRequest>
    {
        public EmployeeFunctionController(ICRUDService<Model.EmployeeFunction, object, EmployeeFunctionUpsertRequest, EmployeeFunctionUpsertRequest> service) : base(service)
        {
        }
    }

}
