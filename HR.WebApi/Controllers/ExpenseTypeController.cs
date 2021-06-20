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
    public class ExpenseTypeController : BaseCRUDController<Model.ExpenseType, object, ExpenseTypeUpsertRequest, ExpenseTypeUpsertRequest>
    {
        public ExpenseTypeController(ICRUDService<Model.ExpenseType, object, ExpenseTypeUpsertRequest, ExpenseTypeUpsertRequest> service) : base(service)
        {
        }
    }

}
