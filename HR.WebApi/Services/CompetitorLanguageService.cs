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
    public class CompetitorLanguageService : BaseCRUDService<Model.CompetitorLanguage, object, Database.CompetitorLanguage, CompetitorLanguageUpsertRequest, CompetitorLanguageUpsertRequest>
    {
        public CompetitorLanguageService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.CompetitorLanguages.Include(x => x.Competitor).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.CompetitorLanguage>>(list);
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
                var query = _context.CompetitorLanguages.Include(x => x.Competitor).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.CompetitorLanguage>(query);
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
            Model.CompetitorLanguage competitorLanguage = new Model.CompetitorLanguage();
            try
            {
                competitorLanguage = GetById(id).Result;
                competitorLanguage.Deleted = true;
                competitorLanguage.Active = false;
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

                response.Result = Update(competitorLanguage.Id, _mapper.Map<CompetitorLanguageUpsertRequest>(competitorLanguage));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
