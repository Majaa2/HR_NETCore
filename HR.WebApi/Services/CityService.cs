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
    public class CityService : BaseCRUDService<Model.City, object, Database.City, CityUpsertRequest, CityUpsertRequest>
    {
        public CityService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.City city = new Model.City();
            try
            {
                city = GetById(id).Result;
                city.Deleted = true;
                city.Active = false;
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

                response.Result = Update(city.Id, _mapper.Map<CityUpsertRequest>(city));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
