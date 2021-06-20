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
    public class HolidayWaitController : BaseCRUDController<Model.HolidayWait, object, HolidayWaitUpsertRequest, HolidayWaitUpsertRequest>
    {
        public HolidayWaitController(ICRUDService<Model.HolidayWait, object, HolidayWaitUpsertRequest, HolidayWaitUpsertRequest> service) : base(service)
        {
        }
    }

}
