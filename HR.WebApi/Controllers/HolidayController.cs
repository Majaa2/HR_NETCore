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
    public class HolidayController : BaseCRUDController<Model.Holiday, object, HolidayUpsertRequest, HolidayUpsertRequest>
    {
        public HolidayController(ICRUDService<Model.Holiday, object, HolidayUpsertRequest, HolidayUpsertRequest> service) : base(service)
        {
        }
    }

}
