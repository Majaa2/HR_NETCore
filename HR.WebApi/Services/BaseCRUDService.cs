using AutoMapper;
using HR.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using HR.WebApi.Interface;
using HR.WebApi.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HR.Model.Helpers;

namespace HR.WebApi.Services
{
    public class BaseCRUDService<TModel, TSearch, TDatabase, TInsert, TUpdate> : BaseService<TModel, TSearch, TDatabase>, ICRUDService<TModel, TSearch, TInsert, TUpdate> where TDatabase : class
    {
        public BaseCRUDService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual HRResponse Insert(TInsert request)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                // TO-DO: Dodati vreated i updated by nakon što login bude
                var entity = _mapper.Map<TDatabase>(request);

                _context.Set<TDatabase>().Add(entity);
                _context.SaveChanges();

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

        public virtual HRResponse Update(int id, TUpdate request)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _context.Set<TDatabase>().Find(id);
                _context.Set<TDatabase>().Attach(entity);
                _context.Set<TDatabase>().Update(entity);

                _mapper.Map(request, entity);

                _context.SaveChanges();

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

        public virtual HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _context.Set<TDatabase>().Find(id);
                _context.Set<TDatabase>().Remove(entity);
                _context.SaveChanges();

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
