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
    public class WorkController : BaseCRUDController<Model.Work, object, WorkUpsertRequest, WorkUpsertRequest>
    {
        public WorkController(ICRUDService<Model.Work, object, WorkUpsertRequest, WorkUpsertRequest> service) : base(service)
        {
        }
    }

}
