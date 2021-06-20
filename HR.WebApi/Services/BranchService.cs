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
    public class BranchService : BaseCRUDService<Model.Branch, object, Database.Branch, BranchUpsertRequest, BranchUpsertRequest>
    {
        public BranchService(HRAngularContext context, IMapper mapper) : base(context, mapper)
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
                var list = _context.Branches.Include(x => x.City).AsQueryable().Where(w => w.Active == true).ToList();
                var employeeBranches = _context.EmployeeBranches.AsQueryable();
                foreach (var branch in list)
                {
                    branch.Number = employeeBranches.Where(x => x.BranchId == branch.Id).ToList().Count();
                }

            response.Result = _mapper.Map<List<Model.Branch>>(list);
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
                var query = _context.Branches.Include(x => x.City).FirstOrDefault(x => x.Id == id);

                response.Result = _mapper.Map<Model.Branch>(query);
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
            Model.Branch branch = new Model.Branch();
            try
            {
                branch = GetById(id).Result;
                branch.Deleted = true;
                branch.Active = false;
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

                response.Result = Update(branch.Id, _mapper.Map<BranchUpsertRequest>(branch));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }

    }
}

