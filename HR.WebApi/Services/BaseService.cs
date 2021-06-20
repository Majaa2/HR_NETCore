using AutoMapper;
using HR.Model.Helpers;
using HR.WebApi.Database;
using HR.WebApi.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class BaseService<TModel, TSearch, TDatabase> : IService<TModel, TSearch> where TDatabase : class
    {
        protected readonly HRAngularContext _context;
        protected readonly IMapper _mapper;
        public BaseService(HRAngularContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual HRResponse Get(TSearch search)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var list = _context.Set<TDatabase>().ToList();
                response.Result = _mapper.Map<List<TModel>>(list);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dobavljanja",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public virtual HRResponse GetById(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _context.Set<TDatabase>().Find(id);
                response.Result = _mapper.Map<TModel>(entity);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dobavljanja",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

    }
}
