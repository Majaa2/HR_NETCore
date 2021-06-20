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
    public class SeminarService : BaseCRUDService<Model.Seminar, object, Database.Seminar, SeminarUpsertRequest, SeminarUpsertRequest>
    {
        public SeminarService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.Seminars.Include(x => x.Currency).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.Seminar>>(list);
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
                var query = _context.Seminars.Include(x => x.Currency).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.Seminar>(query);
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
            Model.Seminar seminar = new Model.Seminar();
            try
            {
                seminar = GetById(id).Result;
                seminar.Deleted = true;
                seminar.Active = false;
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

                response.Result = Update(seminar.Id, _mapper.Map<SeminarUpsertRequest>(seminar));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}

