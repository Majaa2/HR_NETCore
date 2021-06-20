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
    public class SickLeaveController : BaseCRUDController<Model.SickLeave, object, SickLeaveUpsertRequest, SickLeaveUpsertRequest>
    {
        public SickLeaveController(ICRUDService<Model.SickLeave, object, SickLeaveUpsertRequest, SickLeaveUpsertRequest> service) : base(service)
        {
        }
    }

}
