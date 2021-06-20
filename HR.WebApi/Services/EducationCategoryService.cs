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
    public class EducationCategoryService : BaseCRUDService<Model.EducationCategory, object, Database.EducationCategory, EducationCategoryUpsertRequest, EducationCategoryUpsertRequest>
    {
        public EducationCategoryService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.EducationCategory educationCategory = new Model.EducationCategory();
            try
            {
                educationCategory = GetById(id).Result;
                educationCategory.Deleted = true;
                educationCategory.Active = false;
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

                response.Result = Update(educationCategory.Id, _mapper.Map<EducationCategoryUpsertRequest>(educationCategory));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }

    }
}
