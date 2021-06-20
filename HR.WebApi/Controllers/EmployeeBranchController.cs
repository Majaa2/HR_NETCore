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
    public class EmployeeBranchController : BaseCRUDController<Model.EmployeeBranch, object, EmployeeBranchUpsertRequest, EmployeeBranchUpsertRequest>
    {
        public EmployeeBranchController(ICRUDService<Model.EmployeeBranch, object, EmployeeBranchUpsertRequest, EmployeeBranchUpsertRequest> service) : base(service)
        {
        }
    }

}
