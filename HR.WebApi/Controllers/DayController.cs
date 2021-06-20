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
    public class DayController : BaseCRUDController<Model.Day, object, DayUpsertRequest, DayUpsertRequest>
    {
        public DayController(ICRUDService<Model.Day, object, DayUpsertRequest, DayUpsertRequest> service) : base(service)
        {
        }
    }

}
