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
    public class RoleController : BaseCRUDController<Model.Role, object, RoleUpsertRequest, RoleUpsertRequest>
    {
        public RoleController(ICRUDService<Model.Role, object, RoleUpsertRequest, RoleUpsertRequest> service) : base(service)
        {
        }
    }

}
