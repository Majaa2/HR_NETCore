using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
//using HRAngular.Model.Helpers;
using HR.Model.Requests;
//using HR.Model.Searchs;
using HR.WebApi.Database;
using HR.WebApi.Helpers;
using HR.WebApi.Services;
using HR.WebApi.Interface;
using HR.Model;
using Microsoft.OpenApi.Models;
using HR.Model.Helpers;

namespace HR.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
            

            services.AddSwaggerGen();

            services.AddDbContext<HRAngularContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DB")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddAutoMapper(typeof(HRAngularContext));

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://10.15.1.9:8080",
                    ValidAudience = "http://10.15.1.9:8080",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
                };
            });

            services.AddScoped<ICRUDService<Model.Active, object, ActiveUpsertRequest, ActiveUpsertRequest>, ActiveService>();
            services.AddScoped<ICRUDService<Model.Bonus, object, BonusUpsertRequest, BonusUpsertRequest>, BonusService>();
            services.AddScoped<ICRUDService<Model.Branch, object, BranchUpsertRequest, BranchUpsertRequest>, BranchService>();
            services.AddScoped<ICRUDService<Model.BusinessTrip, object, BusinessTripUpsertRequest, BusinessTripUpsertRequest>, BusinessTripService>();
            services.AddScoped<ICRUDService<Model.Calculation, object, CalculationUpsertRequest, CalculationUpsertRequest>, CalculationService>();
            services.AddScoped<ICRUDService<Model.Certificate, object, CertificateUpsertRequest, CertificateUpsertRequest>, CertificateService>();
            services.AddScoped<ICRUDService<Model.City, object, CityUpsertRequest, CityUpsertRequest>, CityService>();
            services.AddScoped<ICRUDService<Model.Competition, object, CompetitionUpsertRequest, CompetitionUpsertRequest>, CompetitionService>();
            services.AddScoped<ICRUDService<Model.CompetitionCall, object, CompetitionCallUpsertRequest, CompetitionCallUpsertRequest>, CompetitionCallService>();
            services.AddScoped<ICRUDService<Model.CompetitionCompetitor, object, CompetitionCompetitorUpsertRequest, CompetitionCompetitorUpsertRequest>, CompetitionCompetitorService>();
            services.AddScoped<ICRUDService<Model.CompetitorLanguage, object, CompetitorLanguageUpsertRequest, CompetitorLanguageUpsertRequest>, CompetitorLanguageService>();
            services.AddScoped<ICRUDService<Model.Competitor, object, CompetitorUpsertRequest, CompetitorUpsertRequest>, CompetitorService>();
            services.AddScoped<ICRUDService<Model.Contributor, object, ContributorUpsertRequest, ContributorUpsertRequest>, ContributorService>();
            services.AddScoped<ICRUDService<Model.Currency, object, CurrencyUpsertRequest, CurrencyUpsertRequest>, CurrencyService>();
            services.AddScoped<ICRUDService<Model.Day, object, DayUpsertRequest, DayUpsertRequest>, DayService>();
            services.AddScoped<ICRUDService<Model.DaysOff, object, DaysOffUpsertRequest, DaysOffUpsertRequest>, DaysOffService>();
            services.AddScoped<ICRUDService<Model.Debt, object, DebtUpsertRequest, DebtUpsertRequest>, DebtService>();
            services.AddScoped<ICRUDService<Model.Department, object, DepartmentUpsertRequest, DepartmentUpsertRequest>, DepartmentService>();
            //services.AddScoped<ICRUDService<Model.Document, object, DocumentUpsertRequest, DocumentUpsertRequest>, DocumentService>();
            services.AddScoped<IDocument, DocumentService>();
            services.AddScoped<ICRUDService<Model.EducationCategory, object, EducationCategoryUpsertRequest, EducationCategoryUpsertRequest>, EducationCategoryService>();
            services.AddScoped<ICRUDService<Model.EmployeeBranch, object, EmployeeBranchUpsertRequest, EmployeeBranchUpsertRequest>, EmployeeBranchService>();
            services.AddScoped<ICRUDService<Model.EmployeeDepartment, object, EmployeeDepartmentUpsertRequest, EmployeeDepartmentUpsertRequest>, EmployeeDepartmentService>();
            services.AddScoped<ICRUDService<Model.EmployeeFunction, object, EmployeeFunctionUpsertRequest, EmployeeFunctionUpsertRequest>, EmployeeFunctionService>();
            services.AddScoped<ICRUDService<Model.EmployeeLanguage, object, EmployeeLanguageUpsertRequest, EmployeeLanguageUpsertRequest>, EmployeeLanguageService>();
            services.AddScoped<ICRUDService<Model.EmployeeRole, object, EmployeeRoleUpsertRequest, EmployeeRoleUpsertRequest>, EmployeeRoleService>();
            services.AddScoped<ICRUDService<Model.EmployeeSeminar, object, EmployeeSeminarUpsertRequest, EmployeeSeminarUpsertRequest>, EmployeeSeminarService>();
            //services.AddScoped<ICRUDService<Model.Employee, object, EmployeeUpsertRequest, EmployeeUpsertRequest>, EmployeeService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<ICRUDService<Model.EmployeeSheetList, object, EmployeeSheetListUpsertRequest, EmployeeSheetListUpsertRequest>, EmployeeSheetListService>();
            services.AddScoped<ICRUDService<Model.Exam, object, ExamUpsertRequest, ExamUpsertRequest>, ExamService>();
            services.AddScoped<ICRUDService<Model.Expense, object, ExpenseUpsertRequest, ExpenseUpsertRequest>, ExpenseService>();
            services.AddScoped<ICRUDService<Model.ExpenseType, object, ExpenseTypeUpsertRequest, ExpenseTypeUpsertRequest>, ExpenseTypeService>();
            services.AddScoped<ICRUDService<Model.Experience, object, ExperienceUpsertRequest, ExperienceUpsertRequest>, ExperienceService>();
            services.AddScoped<ICRUDService<Model.Family, object, FamilyUpsertRequest, FamilyUpsertRequest>, FamilyService>();
            services.AddScoped<ICRUDService<Model.Function, object, FunctionUpsertRequest, FunctionUpsertRequest>, FunctionService>();
            services.AddScoped<ICRUDService<Model.HolidayEmployeeDay, object, HolidayEmployeeDayUpsertRequest, HolidayEmployeeDayUpsertRequest>, HolidayEmployeeDaysService>();
            services.AddScoped<ICRUDService<Model.Holiday, object, HolidayUpsertRequest, HolidayUpsertRequest>, HolidayService>();
            services.AddScoped<ICRUDService<Model.HolidayWait, object, HolidayWaitUpsertRequest, HolidayWaitUpsertRequest>, HolidayWaitService>();
            //services.AddScoped<ICRUDService<Model.Image, object, ImageUpsertRequest, ImageUpsertRequest>, ImageService>();
            services.AddScoped<IImage, ImageService>();
            services.AddScoped<ICRUDService<Model.OvertimePay, object, OvertimePayUpsertRequest, OvertimePayUpsertRequest>, OvertimePayService>();
            //services.AddScoped<ICRUDService<Model.OverTime, object, OverTimeUpsertRequest, OverTimeUpsertRequest>, OverTimeService>();
            services.AddScoped<IOverTime, OverTimeService>();
            services.AddScoped<ICRUDService<Model.PayAbsence, object, PayAbsenceUpsertRequest, PayAbsenceUpsertRequest>, PayAbsenceService>();
            services.AddScoped<ICRUDService<Model.PersonalReason, object, PersonalReasonUpsertRequest, PersonalReasonUpsertRequest>, PersonalReasonService>();
            services.AddScoped<ICRUDService<Model.ReligiousHoliday, object, ReligiousHolidayUpsertRequest, ReligiousHolidayUpsertRequest>, ReligiousHolidayService>();
            services.AddScoped<ICRUDService<Model.Role, object, RoleUpsertRequest, RoleUpsertRequest>, RoleService>();
            services.AddScoped<ICRUDService<Model.Scoring, object, ScoringUpsertRequest, ScoringUpsertRequest>, ScoringService>();
            services.AddScoped<ICRUDService<Model.SeminarOutlay, object, SeminarOutlayUpsertRequest, SeminarOutlayUpsertRequest>, SeminarOutlayService>();
            services.AddScoped<ICRUDService<Model.Seminar, object, SeminarUpsertRequest, SeminarUpsertRequest>, SeminarService>();
            services.AddScoped<ICRUDService<Model.SheetList, object, SheetListUpsertRequest, SheetListUpsertRequest>, SheetListService>();
            services.AddScoped<ICRUDService<Model.SheetListUnlock, object, SheetListUnlockUpsertRequest, SheetListUnlockUpsertRequest>, SheetListUnlockService>();
            //services.AddScoped<ICRUDService<Model.SickLeaveDocument, object, SickLeaveDocumentUpsertRequest, SickLeaveDocumentUpsertRequest>, SickLeaveDocumentService>();
            services.AddScoped<ISickLeaveDocument, SickLeaveDocumentService>();
            services.AddScoped<ICRUDService<Model.SickLeave, object, SickLeaveUpsertRequest, SickLeaveUpsertRequest>, SickLeaveService>();
            services.AddScoped<ICRUDService<Model.Vendor, object, VendorUpsertRequest, VendorUpsertRequest>, VendorService>();
            services.AddScoped<ICRUDService<Model.Work, object, WorkUpsertRequest, WorkUpsertRequest>, WorkService>();


            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);

            services.AddSingleton<IEmail, Email>();




            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build(); 
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
              //  app.UseDeveloperExceptionPage();
            //}

            app.UseAuthentication();
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) &&
                !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            }
                );
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseCors("EnableCORS");


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
