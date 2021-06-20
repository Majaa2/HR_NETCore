using AutoMapper;
using HR.Model.Helpers;
using HR.Model.Requests;
using HR.WebApi.Database;
using HR.WebApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.WebApi.Services
{

     public class EmployeeService : IEmployee
    {

        private readonly HRAngularContext _context;
        private readonly IMapper _mapper;
        private readonly IEmail _emailService;

        public EmployeeService(HRAngularContext context, IMapper mapper, IEmail emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;

        }

        public HRResponse Get()
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 200
            };
            try
            {
                var query = _context.Employees.AsQueryable().Include(x => x.Work).Include(x => x.City).Include(x => x.EducationCategory);
                var list = query.Where(e => e.Deleted == false).ToList();
                var employeeList = _mapper.Map<List<Model.Employee>>(list);
                foreach (var employee in employeeList)
                {
                    var employeeBranches = _context.EmployeeBranches.Include(x => x.Branch).Where(x => x.EmployeeId == employee.Id).ToList();
                    var employeeDepartments = _context.EmployeeDepartments.Include(x => x.Department).Where(x => x.EmployeeId == employee.Id).ToList();
                    var employeeFunctions = _context.EmployeeFunctions.Include(x => x.Function).Where(x => x.EmployeeId == employee.Id).ToList();
                    var employeeRoles = _context.EmployeeRoles.Include(x => x.Role).Where(x => x.EmployeeId == employee.Id).ToList();
                    var employeeSeminars = _context.EmployeeSeminars.Include(x => x.Seminar).Where(x => x.EmployeeId == employee.Id).ToList();
                    var employeeSheetLists = _context.EmployeeSheetLists.Include(x => x.SheetList).Where(x => x.EmployeeId == employee.Id).ToList();

                    var branches = employeeBranches.Select(x => _mapper.Map<Model.Branch>(x.Branch)).ToList();
                    var departments = employeeDepartments.Select(x => _mapper.Map<Model.Department>(x.Department)).ToList();
                    var functions = employeeFunctions.Select(x => _mapper.Map<Model.Function>(x.Function)).ToList();
                    var roles = employeeRoles.Select(x => _mapper.Map<Model.Role>(x.Role)).ToList();
                    var seminars = employeeSeminars.Select(x => _mapper.Map<Model.Seminar>(x.Seminar)).ToList();
                    var sheetLists = employeeSheetLists.Select(x => _mapper.Map<Model.SheetList>(x.SheetList)).ToList();

                    employee.Branches = branches;
                    employee.Departments = departments;
                    employee.Functions = functions;
                    employee.Roles = roles;
                    employee.Seminars = seminars;
                    employee.SheetLists = sheetLists;
                }
 
                response.Result = employeeList;

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
                ResponseCode = 200
            };
            try
            {
                var employee = _context.Employees.Where(e => e.Id == id).Include(x => x.Work).Include(x => x.City).Include(x => x.EducationCategory).AsNoTracking().FirstOrDefault();
                var employee1 = _mapper.Map<Model.Employee>(employee);
                var employeeBranches = _context.EmployeeBranches.Include(x => x.Branch).Where(x => x.EmployeeId == employee.Id).ToList();
                var employeeDepartments = _context.EmployeeDepartments.Include(x => x.Department).Where(x => x.EmployeeId == employee.Id).ToList();
                var employeeFunctions = _context.EmployeeFunctions.Include(x => x.Function).Where(x => x.EmployeeId == employee.Id).ToList();
                var employeeRoles = _context.EmployeeRoles.Include(x => x.Role).Where(x => x.EmployeeId == employee.Id).ToList();
                var employeeSeminars = _context.EmployeeSeminars.Include(x => x.Seminar).Where(x => x.EmployeeId == employee.Id).ToList();
                var employeeSheetLists = _context.EmployeeSheetLists.Include(x => x.SheetList).Where(x => x.EmployeeId == employee.Id).ToList();

                var branches = employeeBranches.Select(x => _mapper.Map<Model.Branch>(x.Branch)).ToList();
                var departments = employeeDepartments.Select(x => _mapper.Map<Model.Department>(x.Department)).ToList();
                var functions = employeeFunctions.Select(x => _mapper.Map<Model.Function>(x.Function)).ToList();
                var roles = employeeRoles.Select(x => _mapper.Map<Model.Role>(x.Role)).ToList();
                var seminars = employeeSeminars.Select(x => _mapper.Map<Model.Seminar>(x.Seminar)).ToList();
                var sheetLists = employeeSheetLists.Select(x => _mapper.Map<Model.SheetList>(x.SheetList)).ToList();

                employee1.Branches = branches;
                employee1.Departments = departments;
                employee1.Functions = functions;
                employee1.Roles = roles;
                employee1.Seminars = seminars;
                employee1.SheetLists = sheetLists;

                response.Result = _mapper.Map<Model.Employee>(employee1);
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


        public HRResponse Add(EmployeeUpsertRequest employee)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Employee>(employee);


                entity.Active = false;
                entity.Deleted = false;
                entity.Created = DateTime.Now;
                entity.ExperienceCount = 0;
                // TO-DO: Dodati vreated i updated by nakon što login bude
                _context.Employees.Add(entity);
                _context.SaveChanges();

                response.Result = _mapper.Map<Model.Employee>(entity);
                response.ResponseMessage = "Zaposlenik je uspješno kreiran";
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom dodavanja zaposlenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {
                // TO-DO: Wrap in a try catch to get exceptions from email sender
                
            }
            return response;
        }
        public HRResponse Update(EmployeeUpsertRequest employeeToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Employee>(employeeToModify);
                var employee = _context.Employees.Attach(entity);
                employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja zaposlenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(employeeToModify.Id).Result;
                response.ResponseMessage = "Zaposlenik je uspješno uređen";
            }

            return response;
        }

        public HRResponse Update(Model.Employee employeeToModify)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            try
            {
                var entity = _mapper.Map<Employee>(employeeToModify);
                var employee = _context.Employees.Attach(entity);
                employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom uređivanja zaposlenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = GetById(employeeToModify.Id).Result;
                response.ResponseMessage = "Zaposlenik je uspješno uređen";
            }
            return response;
        }

        public HRResponse Delete(int id)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Employee employee = new Model.Employee();

            try
            {
                employee = GetById(id).Result;
                employee.Deleted = true;
                employee.Active = false;
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja zaposlenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {

                response.Result = Update(employee);
                response.ResponseMessage = "Zaposlenik je uspješno izbrisan";
            }
            return response;
        }

        public HRResponse CreateAccount(EmployeeUpsertRequest employee, List<int> roleList)
        {
            HRResponse response = new HRResponse
            {
                ResponseCode = 201
            };
            Model.Employee emp = new Model.Employee();
            string pass = Helpers.Password.Generate(8, 2);
            var roleRes = new List<dynamic>();
            try
            {
                employee.Password = Helpers.PasswordGenerator.GenerateHash(pass);
                emp = Update(employee).Result;
                if (emp != null)
                {
                    foreach(var id in roleList)
                    {
                        var roles = _context.EmployeeRoles.Add(new EmployeeRole()
                        {
                            EmployeeId = emp.Id,
                            RoleId = id,
                            Created = DateTime.Now,
                            CreatedBy = emp.ModifiedBy,
                            Deleted = false,
                            Active = true
                        });
                        roleRes.Add(roles);
                    }
                }
            }
            catch (Exception e)
            {
                response = new HRResponse
                {
                    ResponseCode = 500,
                    ResponseMessage = "Dogodila se greška prilikom brisanja zaposlenika!",
                    ErrorList = new List<ResponseError>
                    {
                        new ResponseError {ValueField = e.Message, ErrorDescription = "ExceptionMessage"}
                    }
                };
            }
            finally
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Ime: " + emp.FirstName);
                sb.AppendLine("Prezime: " + emp.LastName);
                sb.AppendLine("Korisničko ime: " + emp.UserName);
                sb.AppendLine("Lozinka: " + pass);

                _emailService.Send(new string[] { employee.Email }, "Pristupni podaci za aplikaciju HR", sb.ToString(), false);
                response.ResponseMessage = "Račun je uspiješno kreiran!";
            }
            return response;
        }
    }


}













