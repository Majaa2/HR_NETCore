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
    public class CurrencyController : BaseCRUDController<Model.Currency, object, CurrencyUpsertRequest, CurrencyUpsertRequest>
    {
        public CurrencyController(ICRUDService<Model.Currency, object, CurrencyUpsertRequest, CurrencyUpsertRequest> service) : base(service)
        {
        }
    }

}
