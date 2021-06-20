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
    [Route("api/[controller]")]

    //[Produces("application/json" )]
    [ApiController]

    public class ActiveController : BaseCRUDController<Model.Active, object, ActiveUpsertRequest, ActiveUpsertRequest>
    {
        public ActiveController(ICRUDService<Model.Active, object, ActiveUpsertRequest, ActiveUpsertRequest> service) : base(service)
        {
        }
    }

}
