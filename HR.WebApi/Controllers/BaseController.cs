using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Model.Helpers;
using HR.WebApi.Interface;
using HR.WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace HR.WebApi.Controllers
{  
    //[Authorize]
    [Route("api/[controller]")]
    //[Produces("application/json")]
    [ApiController]
    public class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IService<T, TSearch> _service;
        public BaseController(IService<T, TSearch> service)
        {
            _service = service;
        }


        [HttpGet("")]
        public HRResponse Get([FromQuery] TSearch search)
        {
            HRResponse response;
            try
            {
                response = _service.Get(search);

            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja zapolenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        [HttpGet("{id}")]
        public HRResponse GetById(int id)
        {
            return _service.GetById(id);
        }

    }

}
