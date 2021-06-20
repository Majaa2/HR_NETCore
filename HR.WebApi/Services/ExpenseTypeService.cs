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
    public class ExpenseTypeService : BaseCRUDService<Model.ExpenseType, object, Database.ExpenseType, ExpenseTypeUpsertRequest, ExpenseTypeUpsertRequest>
    {
        public ExpenseTypeService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.ExpenseType expenseType = new Model.ExpenseType();
            try
            {
                expenseType = GetById(id).Result;
                expenseType.Deleted = true;
                expenseType.Active = false;
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

                response.Result = Update(expenseType.Id, _mapper.Map<ExpenseTypeUpsertRequest>(expenseType));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
