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
    public class PersonalReasonController : BaseCRUDController<Model.PersonalReason, object, PersonalReasonUpsertRequest, PersonalReasonUpsertRequest>
    {
        public PersonalReasonController(ICRUDService<Model.PersonalReason, object, PersonalReasonUpsertRequest, PersonalReasonUpsertRequest> service) : base(service)
        {
        }
    }

}
