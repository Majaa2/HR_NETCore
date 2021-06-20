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
    public class ExamController : BaseCRUDController<Model.Exam, object, ExamUpsertRequest, ExamUpsertRequest>
    {
        public ExamController(ICRUDService<Model.Exam, object, ExamUpsertRequest, ExamUpsertRequest> service) : base(service)
        {
        }
    }

}
