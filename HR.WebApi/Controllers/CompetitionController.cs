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
    public class CompetitionController : BaseCRUDController<Model.Competition, object, CompetitionUpsertRequest, CompetitionUpsertRequest>
    {
        public CompetitionController(ICRUDService<Model.Competition, object, CompetitionUpsertRequest, CompetitionUpsertRequest> service) : base(service)
        {
        }
    }

}
