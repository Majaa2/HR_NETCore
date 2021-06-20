using AutoMapper;
using HR.Model;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Mapper
{
    public class Mappper : Profile
    {
        public Mappper()
        {
            CreateMap<Database.Active, Model.Active>();
            CreateMap<Active, ActiveUpsertRequest>();
            CreateMap<ActiveUpsertRequest, Database.Active>();

            CreateMap<Database.Bonus, Model.Bonus>();
            CreateMap<Bonus, BonusUpsertRequest>();
            CreateMap<BonusUpsertRequest, Database.Bonus>();

            CreateMap<Database.Branch, Model.Branch>();
            CreateMap<Branch, Database.Branch>();
            CreateMap<Branch, BranchUpsertRequest>();
            CreateMap<BranchUpsertRequest, Database.Branch>();

            CreateMap<Database.BusinessTrip, Model.BusinessTrip>();
            CreateMap<BusinessTrip, BusinessTripUpsertRequest>();
            CreateMap<BusinessTripUpsertRequest, Database.BusinessTrip>();


            CreateMap<Database.Calculation, Model.Calculation>();
            CreateMap<Calculation, CalculationUpsertRequest>();
            CreateMap<CalculationUpsertRequest, Database.Calculation>();


            CreateMap<Database.Certificate, Model.Certificate>();
            CreateMap<Certificate, CertificateUpsertRequest>();
            CreateMap<CertificateUpsertRequest, Database.Certificate>();


            CreateMap<Database.City, Model.City>();
            CreateMap<City, CityUpsertRequest>();
            CreateMap<CityUpsertRequest, Database.City>();


            CreateMap<Database.Competition, Model.Competition>();
            CreateMap<Competition, CompetitionUpsertRequest>();
            CreateMap<CompetitionUpsertRequest, Database.Competition>();

            CreateMap<Database.CompetitionCall, Model.CompetitionCall>();
            CreateMap<CompetitionCall, CompetitionCallUpsertRequest>();
            CreateMap<CompetitionCallUpsertRequest, Database.CompetitionCall>();

            CreateMap<Database.CompetitionCompetitor, Model.CompetitionCompetitor>();
            CreateMap<CompetitionCompetitor, CompetitionCompetitorUpsertRequest>();
            CreateMap<CompetitionCompetitorUpsertRequest, Database.CompetitionCompetitor>();

            CreateMap<Database.Competitor, Model.Competitor>();
            CreateMap<Competitor, CompetitorUpsertRequest>();
            CreateMap<CompetitorUpsertRequest, Database.Competitor>();


            CreateMap<Database.CompetitorLanguage, Model.CompetitorLanguage>();
            CreateMap<CompetitorLanguage, CompetitorLanguageUpsertRequest>();
            CreateMap<CompetitorLanguageUpsertRequest, Database.CompetitorLanguage>();


            CreateMap<Database.Contributor, Model.Contributor>();
            CreateMap<Contributor, ContributorUpsertRequest>();
            CreateMap<ContributorUpsertRequest, Database.Contributor>();


            CreateMap<Database.Currency, Model.Currency>();
            CreateMap<Currency, CurrencyUpsertRequest>();
            CreateMap<CurrencyUpsertRequest, Database.Currency>();

            CreateMap<Database.Day, Model.Day>();
            CreateMap<Day, DayUpsertRequest>();
            CreateMap<DayUpsertRequest, Database.Day>();

            CreateMap<Database.DaysOff, Model.DaysOff>();
            CreateMap<DaysOff, DaysOffUpsertRequest>();
            CreateMap<DaysOffUpsertRequest, Database.DaysOff>();

            CreateMap<Database.Debt, Model.Debt>();
            CreateMap<Debt, DebtUpsertRequest>();
            CreateMap<DebtUpsertRequest, Database.Debt>();

            CreateMap<Database.Department, Model.Department>();
            CreateMap<Department, DepartmentUpsertRequest>();
            CreateMap<DepartmentUpsertRequest, Database.Department>();

            CreateMap<Database.Document, Model.Document>();
            CreateMap<Model.Document, Database.Document>();
            CreateMap<DocumentUpsertRequest, Database.Document>();

            CreateMap<Database.EducationCategory, Model.EducationCategory>();
            CreateMap<EducationCategory, EducationCategoryUpsertRequest>();
            CreateMap<EducationCategoryUpsertRequest, Database.EducationCategory>();

            CreateMap<Database.Employee, Model.Employee>();
            CreateMap<Model.Employee, Database.Employee>();
            CreateMap<EmployeeUpsertRequest, Database.Employee>();

            CreateMap<Database.EmployeeBranch, Model.EmployeeBranch>();
            CreateMap<EmployeeBranch, EmployeeBranchUpsertRequest>();
            CreateMap<EmployeeBranchUpsertRequest, Database.EmployeeBranch>();

            CreateMap<Database.EmployeeDepartment, Model.EmployeeDepartment>();
            CreateMap<EmployeeDepartment, EmployeeDepartmentUpsertRequest>();
            CreateMap<EmployeeDepartmentUpsertRequest, Database.EmployeeDepartment>();

            CreateMap<Database.EmployeeFunction, Model.EmployeeFunction>();
            CreateMap<EmployeeFunction, EmployeeFunctionUpsertRequest>();
            CreateMap<EmployeeFunctionUpsertRequest, Database.EmployeeFunction>();

            CreateMap<Database.EmployeeLanguage, Model.EmployeeLanguage>();
            CreateMap<EmployeeLanguage, EmployeeLanguageUpsertRequest>();
            CreateMap<EmployeeLanguageUpsertRequest, Database.EmployeeLanguage>();

            CreateMap<Database.EmployeeRole, Model.EmployeeRole>();
            CreateMap<EmployeeRole, EmployeeRoleUpsertRequest>();
            CreateMap<EmployeeRoleUpsertRequest, Database.EmployeeRole>();

            CreateMap<Database.EmployeeSeminar, Model.EmployeeSeminar>();
            CreateMap<EmployeeSeminar, EmployeeSeminarUpsertRequest>();
            CreateMap<EmployeeSeminarUpsertRequest, Database.EmployeeSeminar>();

            CreateMap<Database.EmployeeSheetList, Model.EmployeeSheetList>();
            CreateMap<EmployeeSheetList, EmployeeSheetListUpsertRequest>();
            CreateMap<EmployeeSheetListUpsertRequest, Database.EmployeeSheetList>();

            CreateMap<Database.Exam, Model.Exam>();
            CreateMap<Exam, ExamUpsertRequest>();
            CreateMap<ExamUpsertRequest, Database.Exam>();

            CreateMap<Database.Expense, Model.Expense>();
            CreateMap<Expense, ExpenseUpsertRequest>();
            CreateMap<ExpenseUpsertRequest, Database.Expense>();

            CreateMap<Database.ExpenseType, Model.ExpenseType>();
            CreateMap<ExpenseType, ExpenseTypeUpsertRequest>();
            CreateMap<ExpenseTypeUpsertRequest, Database.ExpenseType>();

            CreateMap<Database.Experience, Model.Experience>();
            CreateMap<Experience, ExperienceUpsertRequest>();
            CreateMap<ExperienceUpsertRequest, Database.Experience>();

            CreateMap<Database.Family, Model.Family>();
            CreateMap<Family, FamilyUpsertRequest>();
            CreateMap<FamilyUpsertRequest, Database.Family>();

            CreateMap<Database.Function, Model.Function>();
            CreateMap<Function, FunctionUpsertRequest>();
            CreateMap<FunctionUpsertRequest, Database.Function>();

            CreateMap<Database.Holiday, Model.Holiday>();
            CreateMap<Holiday, HolidayUpsertRequest>();
            CreateMap<HolidayUpsertRequest, Database.Holiday>();

            CreateMap<Database.HolidayEmployeeDay, Model.HolidayEmployeeDay>();
            CreateMap<HolidayEmployeeDay, HolidayEmployeeDayUpsertRequest>();
            CreateMap<HolidayEmployeeDayUpsertRequest, Database.HolidayEmployeeDay>();

            CreateMap<Database.HolidayWait, Model.HolidayWait>();
            CreateMap<HolidayWait, HolidayWaitUpsertRequest>();
            CreateMap<HolidayWaitUpsertRequest, Database.HolidayWait>();

            CreateMap<Database.Image, Model.Image>();
            CreateMap<Model.Image, Database.Image>();
            CreateMap<ImageUpsertRequest, Database.Image>();

            CreateMap<Database.OverTime, Model.OverTime>();
            CreateMap<Model.OverTime, Database.OverTime>();
            CreateMap<OverTimeUpsertRequest, Database.OverTime>();

            CreateMap<Database.OvertimePay, Model.OvertimePay>();
            CreateMap<OvertimePay, OvertimePayUpsertRequest>();
            CreateMap<OvertimePayUpsertRequest, Database.OvertimePay>();

            CreateMap<Database.PayAbsence, Model.PayAbsence>();
            CreateMap<PayAbsence, PayAbsenceUpsertRequest>();
            CreateMap<PayAbsenceUpsertRequest, Database.PayAbsence>();

            CreateMap<Database.PersonalReason, Model.PersonalReason>();
            CreateMap<PersonalReason, PersonalReasonUpsertRequest>();
            CreateMap<PersonalReasonUpsertRequest, Database.PersonalReason>();

            CreateMap<Database.ReligiousHoliday, Model.ReligiousHoliday>();
            CreateMap<ReligiousHoliday, ReligiousHolidayUpsertRequest>();
            CreateMap<ReligiousHolidayUpsertRequest, Database.ReligiousHoliday>();

            CreateMap<Database.Role, Model.Role>();
            CreateMap<Role, RoleUpsertRequest>();
            CreateMap<RoleUpsertRequest, Database.Role>();

            CreateMap<Database.Scoring, Model.Scoring>();
            CreateMap<Scoring, ScoringUpsertRequest>();
            CreateMap<ScoringUpsertRequest, Database.Scoring>();

            CreateMap<Database.Seminar, Model.Seminar>();
            CreateMap<Seminar, SeminarUpsertRequest>();
            CreateMap<SeminarUpsertRequest, Database.Seminar>();

            CreateMap<Database.SeminarOutlay, Model.SeminarOutlay>();
            CreateMap<SeminarOutlay, SeminarOutlayUpsertRequest>();
            CreateMap<SeminarOutlayUpsertRequest, Database.SeminarOutlay>();

            CreateMap<Database.SheetList, Model.SheetList>();
            CreateMap<SheetList, SheetListUpsertRequest>();
            CreateMap<SheetListUpsertRequest, Database.SheetList>();

            CreateMap<Database.SheetListUnlock, Model.SheetListUnlock>();
            CreateMap<SheetListUnlock, SheetListUnlockUpsertRequest>();
            CreateMap<SheetListUnlockUpsertRequest, Database.SheetListUnlock>();

            CreateMap<Database.SickLeave, Model.SickLeave>();
            CreateMap<SickLeave, SickLeaveUpsertRequest>();
            CreateMap<SickLeaveUpsertRequest, Database.SickLeave>();

            CreateMap<Database.SickLeaveDocument, Model.SickLeaveDocument>();
            CreateMap<Model.SickLeaveDocument, Database.SickLeaveDocument>();
            CreateMap<SickLeaveDocumentUpsertRequest, Database.SickLeaveDocument>();

            CreateMap<Database.Vendor, Model.Vendor>();
            CreateMap<Vendor, VendorUpsertRequest>();
            CreateMap<VendorUpsertRequest, Database.Vendor>();

            CreateMap<Database.Work, Model.Work>();
            CreateMap<Work, WorkUpsertRequest>();
            CreateMap<WorkUpsertRequest, Database.Work>();


        }
    }
}
