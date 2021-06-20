using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using HR.WebApi.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{
    public class SickLeaveDocumentService : ISickLeaveDocument
    {
        private readonly HRAngularContext _context;
        private readonly IMapper _mapper;
        public SickLeaveDocumentService(HRAngularContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public HRResponse Get()
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.SickLeaveDocuments.AsQueryable();


                var list = query.Where(s => s.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.SickLeaveDocument>>(list);

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

        public HRResponse GetById(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var query = _context.SickLeaveDocuments.Where(s => s.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.SickLeaveDocument>(query);
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

        public  HRResponse Add(SickLeaveDocumentUpsertRequest sickLeaveDocument)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<SickLeaveDocument>(sickLeaveDocument);

                 _context.SickLeaveDocuments.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.SickLeaveDocument>(entity);
                response.ResponseMessage = "Dokument je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja dokumenta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }
        public HRResponse Update(SickLeaveDocumentUpsertRequest sickLeaveDocumentToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<SickLeaveDocument>(sickLeaveDocumentToModify);
                var sickLeaveDocument = _context.SickLeaveDocuments.Attach(entity);
                sickLeaveDocument.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja dokumenta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {
                
                response.Result = GetById(sickLeaveDocumentToModify.Id).Result;
                response.ResponseMessage = "Dokument je uspješno uređen";
            }

            return response; 
        }

        public HRResponse Update(Model.SickLeaveDocument sickLeaveDocumentToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<SickLeaveDocument>(sickLeaveDocumentToModify);
                var sickLeaveDocument = _context.SickLeaveDocuments.Attach(entity);
                sickLeaveDocument.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja dokumenta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(sickLeaveDocumentToModify.Id).Result;
                response.ResponseMessage = "Dokument je uspješno uređen";
            }
            return response;
        }
        public HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.SickLeaveDocument sickLeaveDocument = new Model.SickLeaveDocument();
            try
            {
                sickLeaveDocument = GetById(id).Result;
                sickLeaveDocument.Deleted = true;
                sickLeaveDocument.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja dokumenta!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(sickLeaveDocument);
                response.ResponseMessage = "Dokument je uspješno izbrisan";
            }
            return response;
        }

    }
}
