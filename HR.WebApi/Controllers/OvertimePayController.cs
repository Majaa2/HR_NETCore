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
    public class OvertimePayController : BaseCRUDController<Model.OvertimePay, object, OvertimePayUpsertRequest, OvertimePayUpsertRequest>
    {
        public OvertimePayController(ICRUDService<Model.OvertimePay, object, OvertimePayUpsertRequest, OvertimePayUpsertRequest> service) : base(service)
        {
        }
    }

}
