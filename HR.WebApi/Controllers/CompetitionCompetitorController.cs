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
    public class CompetitionCompetitorController : BaseCRUDController<Model.CompetitionCompetitor, object, CompetitionCompetitorUpsertRequest, CompetitionCompetitorUpsertRequest>
    {
        public CompetitionCompetitorController(ICRUDService<Model.CompetitionCompetitor, object, CompetitionCompetitorUpsertRequest, CompetitionCompetitorUpsertRequest> service) : base(service)
        {
        }
    }

}
