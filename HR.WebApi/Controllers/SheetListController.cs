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
    public class SheetListController : BaseCRUDController<Model.SheetList, object, SheetListUpsertRequest, SheetListUpsertRequest>
    {
        public SheetListController(ICRUDService<Model.SheetList, object, SheetListUpsertRequest, SheetListUpsertRequest> service) : base(service)
        {
        }
    }

}
