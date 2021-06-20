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
    public class CompetitionCallController : BaseCRUDController<Model.CompetitionCall, object, CompetitionCallUpsertRequest, CompetitionCallUpsertRequest>
    {
        public CompetitionCallController(ICRUDService<Model.CompetitionCall, object, CompetitionCallUpsertRequest, CompetitionCallUpsertRequest> service) : base(service)
        {
        }
    }

}
