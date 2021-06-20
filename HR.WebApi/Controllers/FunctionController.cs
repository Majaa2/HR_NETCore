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
    public class FunctionController : BaseCRUDController<Model.Function, object, FunctionUpsertRequest, FunctionUpsertRequest>
    {
        public FunctionController(ICRUDService<Model.Function, object, FunctionUpsertRequest, FunctionUpsertRequest> service) : base(service)
        {
        }
    }

}
