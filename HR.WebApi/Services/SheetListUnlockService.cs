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
    public class SheetListUnlockService : BaseCRUDService<Model.SheetListUnlock, object, Database.SheetListUnlock, SheetListUnlockUpsertRequest, SheetListUnlockUpsertRequest>
    {
        public SheetListUnlockService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var query = _context.SheetListUnlocks.Include(x => x.UnlockByNavigation).Include(x => x.SheetList).AsQueryable();


                var list = query.ToList();

                response.Result = _mapper.Map<List<Model.SheetListUnlock>>(list);
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
                var query = _context.SheetListUnlocks.Include(x => x.UnlockByNavigation).Include(x => x.SheetList).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.SheetListUnlock>(query);
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
            Model.SheetListUnlock sheetListUnlock = new Model.SheetListUnlock();
            try
            {
                sheetListUnlock = GetById(id).Result;
                sheetListUnlock.Deleted = true;
                sheetListUnlock.Active = false;
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

                response.Result = Update(sheetListUnlock.Id, _mapper.Map<SheetListUnlockUpsertRequest>(sheetListUnlock));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}

