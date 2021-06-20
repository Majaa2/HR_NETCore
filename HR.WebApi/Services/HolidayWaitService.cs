﻿using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class HolidayWaitService : BaseCRUDService<Model.HolidayWait, object, Database.HolidayWait, HolidayWaitUpsertRequest, HolidayWaitUpsertRequest>
    {
        public HolidayWaitService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override HRResponse Get(object search)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.HolidayWaits.Include(x => x.Employee).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.HolidayWait>>(list);
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

        public override HRResponse GetById(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.HolidayWaits.Include(x => x.Employee).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.HolidayWait>(query);
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
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.HolidayWait holidayWait = new Model.HolidayWait();
            try
            {
                holidayWait = GetById(id).Result;
                holidayWait.Deleted = true;
                holidayWait.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja!",
                    ErrorList = new List<ResponseError>
                        {
                            new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                        }
                };
            }
            finally
            {

                response.Result = Update(holidayWait.Id, _mapper.Map<HolidayWaitUpsertRequest>(holidayWait));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
