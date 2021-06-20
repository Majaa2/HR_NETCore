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
    public class ContributorService : BaseCRUDService<Model.Contributor, object, Database.Contributor, ContributorUpsertRequest, ContributorUpsertRequest>
    {
        public ContributorService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Contributor contributor = new Model.Contributor();
            try
            {
                contributor = GetById(id).Result;
                contributor.Deleted = true;
                contributor.Active = false;
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

                response.Result = Update(contributor.Id, _mapper.Map<ContributorUpsertRequest>(contributor));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
