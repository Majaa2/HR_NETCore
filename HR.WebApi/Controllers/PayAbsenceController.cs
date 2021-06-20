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
    public class PayAbsenceController : BaseCRUDController<Model.PayAbsence, object, PayAbsenceUpsertRequest, PayAbsenceUpsertRequest>
    {
        public PayAbsenceController(ICRUDService<Model.PayAbsence, object, PayAbsenceUpsertRequest, PayAbsenceUpsertRequest> service) : base(service)
        {
        }
    }

}
