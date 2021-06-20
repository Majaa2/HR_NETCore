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
    public class FunctionService : BaseCRUDService<Model.Function, object, Database.Function, FunctionUpsertRequest, FunctionUpsertRequest>
    {
        public FunctionService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Function function = new Model.Function();
            try
            {
                function = GetById(id).Result;
                function.Deleted = true;
                function.Active = false;
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

                response.Result = Update(function.Id, _mapper.Map<FunctionUpsertRequest>(function));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
