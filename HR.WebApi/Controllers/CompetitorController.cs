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
    public class CompetitorController : BaseCRUDController<Model.Competitor, object, CompetitorUpsertRequest, CompetitorUpsertRequest>
    {
        public CompetitorController(ICRUDService<Model.Competitor, object, CompetitorUpsertRequest, CompetitorUpsertRequest> service) : base(service)
        {
        }
    }

}
