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
    public class ExpenseService : BaseCRUDService<Model.Expense, object, Database.Expense, ExpenseUpsertRequest, ExpenseUpsertRequest>
    {
        public ExpenseService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.Expenses.Include(x => x.Employee).Include(x => x.ExpenseTypes).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.Expense>>(list);
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
                var query = _context.Expenses.Include(x => x.Employee).Include(x => x.ExpenseTypes).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.Expense>(query);
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
            Model.Expense expense = new Model.Expense();
            try
            {
                expense = GetById(id).Result;
                expense.Deleted = true;
                expense.Active = false;
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

                response.Result = Update(expense.Id, _mapper.Map<ExpenseUpsertRequest>(expense));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
