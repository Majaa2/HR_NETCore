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
    public class EmployeeLanguageController : BaseCRUDController<Model.EmployeeLanguage, object, EmployeeLanguageUpsertRequest, EmployeeLanguageUpsertRequest>
    {
        public EmployeeLanguageController(ICRUDService<Model.EmployeeLanguage, object, EmployeeLanguageUpsertRequest, EmployeeLanguageUpsertRequest> service) : base(service)
        {
        }
    }

}
