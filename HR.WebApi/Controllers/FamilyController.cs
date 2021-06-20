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
    public class FamilyController : BaseCRUDController<Model.Family, object, FamilyUpsertRequest, FamilyUpsertRequest>
    {
        public FamilyController(ICRUDService<Model.Family, object, FamilyUpsertRequest, FamilyUpsertRequest> service) : base(service)
        {
        }
    }

}
