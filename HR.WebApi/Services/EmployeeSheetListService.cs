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
    public class EmployeeSheetListService : BaseCRUDService<Model.EmployeeSheetList, object, Database.EmployeeSheetList, EmployeeSheetListUpsertRequest, EmployeeSheetListUpsertRequest>
    {
        public EmployeeSheetListService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.EmployeeSheetLists.Include(x => x.Employee).Include(x => x.SheetList).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.EmployeeSheetList>>(list);
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
                var query = _context.EmployeeSheetLists.Include(x => x.Employee).Include(x => x.SheetList).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.EmployeeSheetList>(query);
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
            Model.EmployeeSheetList employeeSheetList = new Model.EmployeeSheetList();
            try
            {
                employeeSheetList = GetById(id).Result;
                employeeSheetList.Deleted = true;
                employeeSheetList.Active = false;
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

                response.Result = Update(employeeSheetList.Id, _mapper.Map<EmployeeSheetListUpsertRequest>(employeeSheetList));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }

    }
}
