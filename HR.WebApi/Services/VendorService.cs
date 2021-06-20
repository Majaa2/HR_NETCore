using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class VendorService : BaseCRUDService<Model.Vendor, object, Database.Vendor, VendorUpsertRequest, VendorUpsertRequest>
    {
        public VendorService(HRAngularContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Vendor vendor = new Model.Vendor();
            try
            {
                vendor = GetById(id).Result;
                vendor.Deleted = true;
                vendor.Active = false;
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

                response.Result = Update(vendor.Id, _mapper.Map<VendorUpsertRequest>(vendor));
                response.ResponseMessage = "Uspješno izbrisano!";
            }
            return response;
        }
    }
}
