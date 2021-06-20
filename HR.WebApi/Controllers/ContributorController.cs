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
    public class ContributorController : BaseCRUDController<Model.Contributor, object, ContributorUpsertRequest, ContributorUpsertRequest>
    {
        public ContributorController(ICRUDService<Model.Contributor, object, ContributorUpsertRequest, ContributorUpsertRequest> service) : base(service)
        {
        }
    }

}
