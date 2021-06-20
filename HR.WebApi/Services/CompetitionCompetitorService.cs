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
    public class CompetitionCompetitorService : BaseCRUDService<Model.CompetitionCompetitor, object, Database.CompetitionCompetitor, CompetitionCompetitorUpsertRequest, CompetitionCompetitorUpsertRequest>
    {
        public CompetitionCompetitorService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.CompetitionCompetitors.Include(x => x.Competition).Include(x => x.Competitor).Include(x => x.Work).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.CompetitionCompetitor>>(list);
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
                var query = _context.CompetitionCompetitors.Include(x => x.Competition).Include(x => x.Competitor).Include(x => x.Work).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.CompetitionCompetitor>(query);
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
            Model.CompetitionCompetitor competitionCompetitor = new Model.CompetitionCompetitor();
            try
            {
                competitionCompetitor = GetById(id).Result;
                competitionCompetitor.Deleted = true;
                competitionCompetitor.Active = false;
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

                response.Result = Update(competitionCompetitor.Id, _mapper.Map<CompetitionCompetitorUpsertRequest>(competitionCompetitor));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
