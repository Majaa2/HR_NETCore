using AutoMapper;
using HR.Model;
using HR.Model.Helpers;
using HR.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class BusinessTripService : BaseCRUDService<Model.BusinessTrip, object, Database.BusinessTrip, BusinessTripUpsertRequest, BusinessTripUpsertRequest>
    {
        public BusinessTripService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.BusinessTrips.Include(x => x.Employee).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.BusinessTrip>>(list);
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
                var query = _context.BusinessTrips.Include(x => x.Employee).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.BusinessTrip>(query);
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
            Model.BusinessTrip businessTrip = new Model.BusinessTrip();
            try
            {
                businessTrip = GetById(id).Result;
                businessTrip.Deleted = true;
                businessTrip.Active = false;
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

                response.Result = Update(businessTrip.Id, _mapper.Map<BusinessTripUpsertRequest>(businessTrip));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
