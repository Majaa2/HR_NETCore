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
    public class EmployeeSheetListController : BaseCRUDController<Model.EmployeeSheetList, object, EmployeeSheetListUpsertRequest, EmployeeSheetListUpsertRequest>
    {
        public EmployeeSheetListController(ICRUDService<Model.EmployeeSheetList, object, EmployeeSheetListUpsertRequest, EmployeeSheetListUpsertRequest> service) : base(service)
        {
        }
    }

}
