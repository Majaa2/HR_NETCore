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
    public class ExpenseController : BaseCRUDController<Model.Expense, object, ExpenseUpsertRequest, ExpenseUpsertRequest>
    {
        public ExpenseController(ICRUDService<Model.Expense, object, ExpenseUpsertRequest, ExpenseUpsertRequest> service) : base(service)
        {
        }
    }

}
