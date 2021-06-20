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
    public class ExperienceController : BaseCRUDController<Model.Experience, object, ExperienceUpsertRequest, ExperienceUpsertRequest>
    {
        public ExperienceController(ICRUDService<Model.Experience, object, ExperienceUpsertRequest, ExperienceUpsertRequest> service) : base(service)
        {
        }
    }

}
