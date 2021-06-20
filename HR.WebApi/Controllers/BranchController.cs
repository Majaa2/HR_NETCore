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
    public class BranchController : BaseCRUDController<Model.Branch, object, BranchUpsertRequest, BranchUpsertRequest>
    {
        public BranchController(ICRUDService<Model.Branch, object, BranchUpsertRequest, BranchUpsertRequest> service) : base(service)
        {
        }
    }

}
