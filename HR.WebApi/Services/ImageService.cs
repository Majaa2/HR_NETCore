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
    public class ImageService : IImage
    {
        private readonly HRAngularContext _context;
        private readonly IMapper _mapper;

        public ImageService(HRAngularContext context, IMapper mapper)
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
                var query = _context.Images.AsQueryable();


                var list = query.Where(i => i.Active == true).ToList();

                response.Result = _mapper.Map<List<Model.Image>>(list);

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
                var image = _context.Images.Where(e => e.Id == id).AsNoTracking().FirstOrDefault();

                response.Result = _mapper.Map<Model.Image>(image);
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


        public HRResponse Add(ImageUpsertRequest image)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };

            try
            {
                var entity = _mapper.Map<Image>(image);


                _context.Images.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Image>(entity);
                response.ResponseMessage = "Slika je uspješno kreirana";
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja slike!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }

            return response;
        }

        public HRResponse Update(ImageUpsertRequest imageToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Image>(imageToModify);
                var image = _context.Images.Attach(entity);
                image.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja slike!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(imageToModify.Id).Result;
                response.ResponseMessage = "Slika je uspješno uređena";
            }

            return response;
        }

        public HRResponse Update(Model.Image imageToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Image>(imageToModify);
                var image = _context.Images.Attach(entity);
                image.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja slike!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(imageToModify.Id).Result;
                response.ResponseMessage = "Slike je uspješno uređen";
            }
            return response;
        }

        public HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Image image = new Model.Image();
            try
            {
                image = GetById(id).Result;
                image.Active = false;
                image.Deleted = true;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja slike!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(image);
                response.ResponseMessage = "Slika je uspješno izbrisana";
            }
            return response;
        }
    }
}










