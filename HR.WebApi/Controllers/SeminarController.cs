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
    public class SeminarController : BaseCRUDController<Model.Seminar, object, SeminarUpsertRequest, SeminarUpsertRequest>
    {
        public SeminarController(ICRUDService<Model.Seminar, object, SeminarUpsertRequest, SeminarUpsertRequest> service) : base(service)
        {
        }
    }

}
