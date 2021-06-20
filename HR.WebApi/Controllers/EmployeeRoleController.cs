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
    public class EmployeeRoleController : BaseCRUDController<Model.EmployeeRole, object, EmployeeRoleUpsertRequest, EmployeeRoleUpsertRequest>
    {
        public EmployeeRoleController(ICRUDService<Model.EmployeeRole, object, EmployeeRoleUpsertRequest, EmployeeRoleUpsertRequest> service) : base(service)
        {
        }
    }

}
