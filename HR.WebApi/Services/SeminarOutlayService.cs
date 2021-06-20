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
    public class SeminarOutlayService : BaseCRUDService<Model.SeminarOutlay, object, Database.SeminarOutlay, SeminarOutlayUpsertRequest, SeminarOutlayUpsertRequest>
    {
        public SeminarOutlayService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.SeminarOutlays.Include(x => x.Seminar).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.SeminarOutlay>>(list);
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
                var query = _context.SeminarOutlays.Include(x => x.Seminar).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.SeminarOutlay>(query);
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
            Model.SeminarOutlay seminarOutlay = new Model.SeminarOutlay();
            try
            {
                seminarOutlay = GetById(id).Result;
                seminarOutlay.Deleted = true;
                seminarOutlay.Active = false;
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

                response.Result = Update(seminarOutlay.Id, _mapper.Map<SeminarOutlayUpsertRequest>(seminarOutlay));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}

