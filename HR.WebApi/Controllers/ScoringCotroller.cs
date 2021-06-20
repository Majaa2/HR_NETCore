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
    public class ScoringController : BaseCRUDController<Model.Scoring, object, ScoringUpsertRequest, ScoringUpsertRequest>
    {
        public ScoringController(ICRUDService<Model.Scoring, object, ScoringUpsertRequest, ScoringUpsertRequest> service) : base(service)
        {
        }
    }

}
