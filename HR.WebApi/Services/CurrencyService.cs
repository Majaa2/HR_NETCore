using AutoMapper;
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
    public class CurrencyService : BaseCRUDService<Model.Currency, object, Database.Currency, CurrencyUpsertRequest, CurrencyUpsertRequest>
    {
        public CurrencyService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Currency currency = new Model.Currency();
            try
            {
                currency = GetById(id).Result;
                currency.Deleted = true;
                currency.Active = false;
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

                response.Result = Update(currency.Id, _mapper.Map<CurrencyUpsertRequest>(currency));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
