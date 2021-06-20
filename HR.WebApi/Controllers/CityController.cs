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
    public class CityController : BaseCRUDController<Model.City, object, CityUpsertRequest, CityUpsertRequest>
    {
        public CityController(ICRUDService<Model.City, object, CityUpsertRequest, CityUpsertRequest> service) : base(service)
        {
        }
    }

}
