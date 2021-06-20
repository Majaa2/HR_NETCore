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
    public class SheetListUnlockController : BaseCRUDController<Model.SheetListUnlock, object, SheetListUnlockUpsertRequest, SheetListUnlockUpsertRequest>
    {
        public SheetListUnlockController(ICRUDService<Model.SheetListUnlock, object, SheetListUnlockUpsertRequest, SheetListUnlockUpsertRequest> service) : base(service)
        {
        }
    }

}
