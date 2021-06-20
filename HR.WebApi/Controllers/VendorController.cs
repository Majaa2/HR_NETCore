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
    public class VendorController : BaseCRUDController<Model.Vendor, object, VendorUpsertRequest, VendorUpsertRequest>
    {
        public VendorController(ICRUDService<Model.Vendor, object, VendorUpsertRequest, VendorUpsertRequest> service) : base(service)
        {
        }
    }

}
