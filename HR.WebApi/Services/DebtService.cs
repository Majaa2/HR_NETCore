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
    public class DebtService : BaseCRUDService<Model.Debt, object, Database.Debt, DebtUpsertRequest, DebtUpsertRequest>
    {
        public DebtService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.Debts.Include(x => x.Employee).Include(x => x.Branch).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.Debt>>(list);
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
                var query = _context.Debts.Include(x => x.Employee).Include(x => x.Branch).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.Debt>(query);
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
            Model.Debt debt = new Model.Debt();
            try
            {
                debt = GetById(id).Result;
                debt.Deleted = true;
                debt.Active = false;
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

                response.Result = Update(debt.Id, _mapper.Map<DebtUpsertRequest>(debt));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
