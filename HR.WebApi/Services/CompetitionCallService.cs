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
    public class CompetitionCallService : BaseCRUDService<Model.CompetitionCall, object, Database.CompetitionCall, CompetitionCallUpsertRequest, CompetitionCallUpsertRequest>
    {
        public CompetitionCallService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.CompetitionCalls.Include(x => x.Competition).Include(x => x.Competitor).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.CompetitionCall>>(list);
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
                var query = _context.CompetitionCalls.Include(x => x.Competition).Include(x => x.Competitor).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.CompetitionCall>(query);
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
            Model.CompetitionCall competitionCall = new Model.CompetitionCall();
            try
            {
                competitionCall = GetById(id).Result;
                competitionCall.Deleted = true;
                competitionCall.Active = false;
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

                response.Result = Update(competitionCall.Id, _mapper.Map<CompetitionCallUpsertRequest>(competitionCall));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
