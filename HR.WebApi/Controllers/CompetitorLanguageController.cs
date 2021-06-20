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
    public class CompetitorLanguageController : BaseCRUDController<Model.CompetitorLanguage, object, CompetitorLanguageUpsertRequest, CompetitorLanguageUpsertRequest>
    {
        public CompetitorLanguageController(ICRUDService<Model.CompetitorLanguage, object, CompetitorLanguageUpsertRequest, CompetitorLanguageUpsertRequest> service) : base(service)
        {
        }
    }

}
