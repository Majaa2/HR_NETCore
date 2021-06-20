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
    public class RoleService : BaseCRUDService<Model.Role, object, Database.Role, RoleUpsertRequest, RoleUpsertRequest>
    {
        public RoleService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        { }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Role role = new Model.Role();
            try
            {
                role = GetById(id).Result;
                role.Deleted = true;
                role.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja uloge!",
                    ErrorList = new List<ResponseError>
                        {
                            new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                        }
                };
            }
            finally
            {

                response.Result = Update(role.Id, _mapper.Map<RoleUpsertRequest>(role));
                response.ResponseMessage = "Uloga je uspješno izbrisan";
            }
            return response;
        }
    }
}
