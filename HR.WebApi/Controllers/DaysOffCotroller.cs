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
    public class DaysOffController : BaseCRUDController<Model.DaysOff, object, DaysOffUpsertRequest, DaysOffUpsertRequest>
    {
        public DaysOffController(ICRUDService<Model.DaysOff, object, DaysOffUpsertRequest, DaysOffUpsertRequest> service) : base(service)
        {
        }
    }

}
