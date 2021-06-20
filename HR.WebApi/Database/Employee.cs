using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Employee
    {
        public Employee()
        {
            Actives = new HashSet<Active>();
            Bonus = new HashSet<Bonu>();
            BusinessTrips = new HashSet<BusinessTrip>();
            Calculations = new HashSet<Calculation>();
            Certificates = new HashSet<Certificate>();
            DaysOffs = new HashSet<DaysOff>();
            Debts = new HashSet<Debt>();
            Documents = new HashSet<Document>();
            EmployeeBranches = new HashSet<EmployeeBranch>();
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
            EmployeeFunctions = new HashSet<EmployeeFunction>();
            EmployeeLanguages = new HashSet<EmployeeLanguage>();
            EmployeeRoles = new HashSet<EmployeeRole>();
            EmployeeSeminars = new HashSet<EmployeeSeminar>();
            EmployeeSheetLists = new HashSet<EmployeeSheetList>();
            Expenses = new HashSet<Expense>();
            Experiences = new HashSet<Experience>();
            Families = new HashSet<Family>();
            HolidayEmployeeDays = new HashSet<HolidayEmployeeDay>();
            HolidayWaits = new HashSet<HolidayWait>();
            Holidays = new HashSet<Holiday>();
            Images = new HashSet<Image>();
            OverTimes = new HashSet<OverTime>();
            OvertimePays = new HashSet<OvertimePay>();
            PayAbsences = new HashSet<PayAbsence>();
            PersonalReasons = new HashSet<PersonalReason>();
            ReligiousHolidays = new HashSet<ReligiousHoliday>();
            Scorings = new HashSet<Scoring>();
            SheetListUnlocks = new HashSet<SheetListUnlock>();
            SickLeaves = new HashSet<SickLeave>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
        public string IdCard { get; set; }
        public string Sex { get; set; }
        public string MarriageStatus { get; set; }
        public string DrivingLicence { get; set; }
        public string CategoryDl { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string BirthTownship { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Qualifications { get; set; }
        public string Profession { get; set; }
        public string EduInstitution { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public int? ExperienceCount { get; set; }
        public string Citizenship { get; set; }
        public string Nationality { get; set; }
        public string SpecialKnowledgeAndSkills { get; set; }
        public string Disability { get; set; }
        public string EntityOfResidence { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string BloodType { get; set; }
        public string Code { get; set; }
        public string Points { get; set; }
        public int? CityId { get; set; }
        public int? WorkId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }
        public string MaidenName { get; set; }
        public int? EducationCategoryId { get; set; }

        public virtual City City { get; set; }
        public virtual EducationCategory EducationCategory { get; set; }
        public virtual Work Work { get; set; }
        public virtual ICollection<Active> Actives { get; set; }
        public virtual ICollection<Bonu> Bonus { get; set; }
        public virtual ICollection<BusinessTrip> BusinessTrips { get; set; }
        public virtual ICollection<Calculation> Calculations { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<DaysOff> DaysOffs { get; set; }
        public virtual ICollection<Debt> Debts { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EmployeeFunction> EmployeeFunctions { get; set; }
        public virtual ICollection<EmployeeLanguage> EmployeeLanguages { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
        public virtual ICollection<EmployeeSeminar> EmployeeSeminars { get; set; }
        public virtual ICollection<EmployeeSheetList> EmployeeSheetLists { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<HolidayEmployeeDay> HolidayEmployeeDays { get; set; }
        public virtual ICollection<HolidayWait> HolidayWaits { get; set; }
        public virtual ICollection<Holiday> Holidays { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OverTime> OverTimes { get; set; }
        public virtual ICollection<OvertimePay> OvertimePays { get; set; }
        public virtual ICollection<PayAbsence> PayAbsences { get; set; }
        public virtual ICollection<PersonalReason> PersonalReasons { get; set; }
        public virtual ICollection<ReligiousHoliday> ReligiousHolidays { get; set; }
        public virtual ICollection<Scoring> Scorings { get; set; }
        public virtual ICollection<SheetListUnlock> SheetListUnlocks { get; set; }
        public virtual ICollection<SickLeave> SickLeaves { get; set; }
    }
}
