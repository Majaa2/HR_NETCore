using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using HR.WebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class OverTimeService : IOverTime
    {
        private readonly HRAngularContext _context;
        private readonly IMapper _mapper;
        public OverTimeService(HRAngularContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HRResponse Get()
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.OverTimes.AsQueryable();

                var list = query.Where(o => o.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.OverTime>>(list);

            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public HRResponse GetById(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var overTime = _context.OverTimes.Where(o => o.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.OverTime>(overTime);
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dohvaćanja podataka",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }


        public HRResponse Add(OverTimeUpsertRequest overTime)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<OverTime>(overTime);
                _context.OverTimes.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.SickLeaveDocument>(entity);
                response.ResponseMessage = "Prekovremeni je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja prekovremenog!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            return response;
        }

        public HRResponse Update(OverTimeUpsertRequest overTimeToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<OverTime>(overTimeToModify);
                var overTime = _context.OverTimes.Attach(entity);
                overTime.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja prekovremenog!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(overTimeToModify.Id).Result;
                response.ResponseMessage = "Prekovremeni je uspješno uređen";
            }

            return response;
        }
        public HRResponse Update(Model.OverTime overTimeToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<OverTime>(overTimeToModify);
                var overTime = _context.OverTimes.Attach(entity);
                overTime.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja prekovremenog!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(overTimeToModify.Id).Result;
                response.ResponseMessage = "Prekovremeni je uspješno uređen";
            }
            return response;
        }
  
        public HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.OverTime overTime = new Model.OverTime();
            try
            {
                overTime = GetById(id).Result;
                overTime.Deleted = true;
                overTime.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja prekovremenog!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(overTime);
                response.ResponseMessage = "Prekovremeni je uspješno izbrisan";
            }
            return response;
        }
    }
}



