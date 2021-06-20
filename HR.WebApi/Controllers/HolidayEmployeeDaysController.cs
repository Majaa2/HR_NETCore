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
    public class HolidayEmployeeDaysController : BaseCRUDController<Model.HolidayEmployeeDay, object, HolidayEmployeeDayUpsertRequest, HolidayEmployeeDayUpsertRequest>
    {
        public HolidayEmployeeDaysController(ICRUDService<Model.HolidayEmployeeDay, object, HolidayEmployeeDayUpsertRequest, HolidayEmployeeDayUpsertRequest> service) : base(service)
        {
        }
    }

}
