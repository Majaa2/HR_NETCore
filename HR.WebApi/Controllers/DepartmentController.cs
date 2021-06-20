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
    public class DepartmentController : BaseCRUDController<Model.Department, object, DepartmentUpsertRequest, DepartmentUpsertRequest>
    {
        public DepartmentController(ICRUDService<Model.Department, object, DepartmentUpsertRequest, DepartmentUpsertRequest> service) : base(service)
        {
        }
    }

}
