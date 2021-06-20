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
    public class CertificateController : BaseCRUDController<Model.Certificate, object, CertificateUpsertRequest, CertificateUpsertRequest>
    {
        public CertificateController(ICRUDService<Model.Certificate, object, CertificateUpsertRequest, CertificateUpsertRequest> service) : base(service)
        {
        }
    }

}
