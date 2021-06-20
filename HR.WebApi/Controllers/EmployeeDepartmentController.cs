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
    public class EmployeeDepartmentController : BaseCRUDController<Model.EmployeeDepartment, object, EmployeeDepartmentUpsertRequest, EmployeeDepartmentUpsertRequest>
    {
        public EmployeeDepartmentController(ICRUDService<Model.EmployeeDepartment, object, EmployeeDepartmentUpsertRequest, EmployeeDepartmentUpsertRequest> service) : base(service)
        {
        }
    }

}
