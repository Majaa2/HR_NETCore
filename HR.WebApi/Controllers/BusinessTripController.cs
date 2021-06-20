using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Model;
using HR.Model.Requests;
using HR.WebApi.Interface;
using HR.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HR.WebApi.Controllers
{
    public class BusinessTripController : BaseCRUDController<Model.BusinessTrip, object, BusinessTripUpsertRequest, BusinessTripUpsertRequest>
    {
        public BusinessTripController(ICRUDService<Model.BusinessTrip, object, BusinessTripUpsertRequest, BusinessTripUpsertRequest> service) : base(service)
        {
        }
    }

}
