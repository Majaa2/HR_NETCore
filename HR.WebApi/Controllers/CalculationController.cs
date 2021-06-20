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
    public class CalculationController : BaseCRUDController<Model.Calculation, object, CalculationUpsertRequest, CalculationUpsertRequest>
    {
        public CalculationController(ICRUDService<Model.Calculation, object, CalculationUpsertRequest, CalculationUpsertRequest> service) : base(service)
        {
        }
    }

}
