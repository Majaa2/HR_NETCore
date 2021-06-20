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
    [ApiController]

    public class BonusController : BaseCRUDController<Model.Bonus, object, BonusUpsertRequest, BonusUpsertRequest>
    {
        public BonusController(ICRUDService<Model.Bonus, object, BonusUpsertRequest, BonusUpsertRequest> service) : base(service)
        {
        }
    }

}
