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
    public class DebtController : BaseCRUDController<Model.Debt, object, DebtUpsertRequest, DebtUpsertRequest>
    {
        public DebtController(ICRUDService<Model.Debt, object, DebtUpsertRequest, DebtUpsertRequest> service) : base(service)
        {
        }
    }

}
