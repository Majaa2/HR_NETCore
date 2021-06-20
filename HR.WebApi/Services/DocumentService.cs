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
    public class DocumentService : IDocument
    {
        private readonly HRAngularContext _context;
        private readonly IMapper _mapper;
        public DocumentService(HRAngularContext context, IMapper mapper)
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
                var query = _context.Documents.AsQueryable();

                var list = query.Where(d => d.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.Document>>(list);

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
                var document = _context.Documents.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.Document>(document);
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

        public HRResponse Add(DocumentUpsertRequest document)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<Document>(document);

                _context.Documents.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Document>(entity);
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

        public HRResponse Update(DocumentUpsertRequest documentToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Document>(documentToModify);
                var document = _context.Documents.Attach(entity);
                document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

                response.Result = GetById(documentToModify.Id).Result;
                response.ResponseMessage = "Dokument je uspješno uređen";
            }

            return response;
        }

        public HRResponse Update(Model.Document documentToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Document>(documentToModify);
                var document = _context.Documents.Attach(entity);
                document.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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

                response.Result = GetById(documentToModify.Id).Result;
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
            Model.Document document = new Model.Document();
            try
            {
                document = GetById(id).Result;
                document.Deleted = true;
                document.Active = false;
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

                response.Result = Update(document);
                response.ResponseMessage = "Dokument je uspješno izbrisan";
            }
            return response;
        }
    }
}









