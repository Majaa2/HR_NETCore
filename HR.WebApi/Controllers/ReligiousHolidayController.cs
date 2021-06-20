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
    public class ReligiousHolidayController : BaseCRUDController<Model.ReligiousHoliday, object, ReligiousHolidayUpsertRequest, ReligiousHolidayUpsertRequest>
    {
        public ReligiousHolidayController(ICRUDService<Model.ReligiousHoliday, object, ReligiousHolidayUpsertRequest, ReligiousHolidayUpsertRequest> service) : base(service)
        {
        }
    }

}
