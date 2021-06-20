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
    public class EducationCategoryController : BaseCRUDController<Model.EducationCategory, object, EducationCategoryUpsertRequest, EducationCategoryUpsertRequest>
    {
        public EducationCategoryController(ICRUDService<Model.EducationCategory, object, EducationCategoryUpsertRequest, EducationCategoryUpsertRequest> service) : base(service)
        {
        }
    }

}
