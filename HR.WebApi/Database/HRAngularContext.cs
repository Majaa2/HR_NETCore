using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class HRAngularContext : DbContext
    {
        public HRAngularContext()
        {
        }

        public HRAngularContext(DbContextOptions<HRAngularContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Active> Actives { get; set; }
        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<BusinessTrip> BusinessTrips { get; set; }
        public virtual DbSet<Calculation> Calculations { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionCall> CompetitionCalls { get; set; }
        public virtual DbSet<CompetitionCompetitor> CompetitionCompetitors { get; set; }
        public virtual DbSet<Competitor> Competitors { get; set; }
        public virtual DbSet<CompetitorLanguage> CompetitorLanguages { get; set; }
        public virtual DbSet<Contributor> Contributors { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Day> Days { get; set; }
        public virtual DbSet<DaysOff> DaysOffs { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<EducationCategory> EducationCategories { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeBranch> EmployeeBranches { get; set; }
        public virtual DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual DbSet<EmployeeFunction> EmployeeFunctions { get; set; }
        public virtual DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public virtual DbSet<EmployeeSeminar> EmployeeSeminars { get; set; }
        public virtual DbSet<EmployeeSheetList> EmployeeSheetLists { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<HolidayEmployeeDay> HolidayEmployeeDays { get; set; }
        public virtual DbSet<HolidayWait> HolidayWaits { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<OverTime> OverTimes { get; set; }
        public virtual DbSet<OvertimePay> OvertimePays { get; set; }
        public virtual DbSet<PayAbsence> PayAbsences { get; set; }
        public virtual DbSet<PersonalReason> PersonalReasons { get; set; }
        public virtual DbSet<ReligiousHoliday> ReligiousHolidays { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Scoring> Scorings { get; set; }
        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<SeminarOutlay> SeminarOutlays { get; set; }
        public virtual DbSet<SheetList> SheetLists { get; set; }
        public virtual DbSet<SheetListUnlock> SheetListUnlocks { get; set; }
        public virtual DbSet<SickLeave> SickLeaves { get; set; }
        public virtual DbSet<SickLeaveDocument> SickLeaveDocuments { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Work> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Initial Catalog=HRAngular;Database=HRAngular;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Croatian_CI_AS");

            modelBuilder.Entity<Active>(entity =>
            {
                entity.ToTable("Active");

                entity.Property(e => e.Active1).HasColumnName("Active");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Actives)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Active_Employee");
            });

            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Bonus_Employee");
            });

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Branch_City");
            });

            modelBuilder.Entity<BusinessTrip>(entity =>
            {
                entity.ToTable("BusinessTrip");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.BusinessTrips)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_BusinessTrip_Employee");
            });

            modelBuilder.Entity<Calculation>(entity =>
            {
                entity.ToTable("Calculation");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Calculations)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Calculation_Employee");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Code).HasMaxLength(100);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EmployeeCertificateAllotDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCertificateComplete).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCertificateDeadlinDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCertificateExpires).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCertificateStatus).HasMaxLength(50);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Certificate_Currency");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Certificate_Employee");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK_Certificate_Vendor");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(100);
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.ToTable("Competition");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.PassFirstRoundDate).HasColumnType("datetime");

                entity.Property(e => e.PassSecondRoundDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(225);

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_Competition_Work");
            });

            modelBuilder.Entity<CompetitionCall>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionCalls)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("FK_CompetitionCalls_Competition");

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.CompetitionCalls)
                    .HasForeignKey(d => d.CompetitorId)
                    .HasConstraintName("FK_CompetitionCalls_Competitor");
            });

            modelBuilder.Entity<CompetitionCompetitor>(entity =>
            {
                entity.ToTable("CompetitionCompetitor");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.PassDateFirstRound).HasColumnType("datetime");

                entity.Property(e => e.PassDateSecondRound).HasColumnType("datetime");

                entity.Property(e => e.Received).HasColumnType("datetime");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionCompetitors)
                    .HasForeignKey(d => d.CompetitionId)
                    .HasConstraintName("FK_CompetitionCompetitor_Competition");

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.CompetitionCompetitors)
                    .HasForeignKey(d => d.CompetitorId)
                    .HasConstraintName("FK_CompetitionCompetitor_Competitor");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.CompetitionCompetitors)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_CompetitionCompetitor_Work");
            });

            modelBuilder.Entity<Competitor>(entity =>
            {
                entity.ToTable("Competitor");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");

                entity.Property(e => e.DrivingLicence)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Profession).HasMaxLength(225);

                entity.Property(e => e.Qualificaations).HasMaxLength(225);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Competitors)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Competitor_City");
            });

            modelBuilder.Entity<CompetitorLanguage>(entity =>
            {
                entity.ToTable("CompetitorLanguage");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.LanguageLevel).HasMaxLength(100);

                entity.Property(e => e.LanguageName).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Competitor)
                    .WithMany(p => p.CompetitorLanguages)
                    .HasForeignKey(d => d.CompetitorId)
                    .HasConstraintName("FK_CompetitorLanguage_Competitor");
            });

            modelBuilder.Entity<Contributor>(entity =>
            {
                entity.ToTable("Contributor");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(100);

                entity.Property(e => e.IdNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("Currency");

                entity.Property(e => e.CodeAlfa).HasMaxLength(10);

                entity.Property(e => e.CodeNum).HasMaxLength(10);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Symbol).HasMaxLength(10);
            });

            modelBuilder.Entity<Day>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.EmployeeSheetList)
                    .WithMany(p => p.Days)
                    .HasForeignKey(d => d.EmployeeSheetListId)
                    .HasConstraintName("FK_Days_EmployeeSheetList");
            });

            modelBuilder.Entity<DaysOff>(entity =>
            {
                entity.ToTable("DaysOff");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateOf).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.DaysOffs)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_DaysOff_Employee");
            });

            modelBuilder.Entity<Debt>(entity =>
            {
                entity.ToTable("Debt");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.InventoryNumber).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Debts)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_Debt_Branch");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Debts)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Debt_Employee");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Complex).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Profession).HasMaxLength(225);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Document1).HasColumnName("Document");

                entity.Property(e => e.Group).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.Subgroup).HasMaxLength(100);

                entity.Property(e => e.Upload).HasColumnType("datetime");

                entity.Property(e => e.ValidTo).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Document_Employee");
            });

            modelBuilder.Entity<EducationCategory>(entity =>
            {
                entity.ToTable("EducationCategory");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.BirthPlace).HasMaxLength(100);

                entity.Property(e => e.BirthTownship).HasMaxLength(100);

                entity.Property(e => e.BloodType).HasMaxLength(50);

                entity.Property(e => e.CategoryDl)
                    .HasMaxLength(10)
                    .HasColumnName("CategoryDL");

                entity.Property(e => e.Citizenship).HasMaxLength(100);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.County).HasMaxLength(100);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Disability).HasMaxLength(225);

                entity.Property(e => e.DrivingLicence).HasMaxLength(100);

                entity.Property(e => e.EduInstitution).HasMaxLength(225);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.EntityOfResidence).HasMaxLength(100);

                entity.Property(e => e.FatherName).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.IdCard).HasMaxLength(100);

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(13)
                    .HasColumnName("JMBG");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.MaidenName)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.MarriageStatus).HasMaxLength(100);

                entity.Property(e => e.MobilePhone).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.MotherLastName).HasMaxLength(100);

                entity.Property(e => e.MotherName).HasMaxLength(100);

                entity.Property(e => e.Municipality).HasMaxLength(100);

                entity.Property(e => e.Nationality).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(100);

                entity.Property(e => e.Place).HasMaxLength(100);

                entity.Property(e => e.Points).HasMaxLength(50);

                entity.Property(e => e.Profession).HasMaxLength(100);

                entity.Property(e => e.Qualifications).HasMaxLength(225);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_Employee_City");

                entity.HasOne(d => d.EducationCategory)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EducationCategoryId)
                    .HasConstraintName("FK_Employee_EducationCategory");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_Employee_Work");
            });

            modelBuilder.Entity<EmployeeBranch>(entity =>
            {
                entity.ToTable("EmployeeBranch");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.EmployeeBranches)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK_EmployeeBranch_Branch");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeBranches)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeBranch_Employee");
            });

            modelBuilder.Entity<EmployeeDepartment>(entity =>
            {
                entity.ToTable("EmployeeDepartment");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_EmployeeDepartment_Department");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeDepartments)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeDepartment_Employee");
            });

            modelBuilder.Entity<EmployeeFunction>(entity =>
            {
                entity.ToTable("EmployeeFunction");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.End).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Start).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeFunctions)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeFunction_Employee");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.EmployeeFunctions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_EmployeeFunction_Function");
            });

            modelBuilder.Entity<EmployeeLanguage>(entity =>
            {
                entity.ToTable("EmployeeLanguage");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.LanguageLevel).HasMaxLength(100);

                entity.Property(e => e.LanguageName).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeLanguages)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeLanguage_Employee");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("EmployeeRole");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeRole_Employee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_EmployeeRole_Role");
            });

            modelBuilder.Entity<EmployeeSeminar>(entity =>
            {
                entity.ToTable("EmployeeSeminar");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSeminars)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeSeminar_Employee");

                entity.HasOne(d => d.Seminar)
                    .WithMany(p => p.EmployeeSeminars)
                    .HasForeignKey(d => d.SeminarId)
                    .HasConstraintName("FK_EmployeeSeminar_Seminar");
            });

            modelBuilder.Entity<EmployeeSheetList>(entity =>
            {
                entity.ToTable("EmployeeSheetList");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSheetLists)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeSheetList_Employee");

                entity.HasOne(d => d.SheetList)
                    .WithMany(p => p.EmployeeSheetLists)
                    .HasForeignKey(d => d.SheetListId)
                    .HasConstraintName("FK_EmployeeSheetList_SheetList");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Code).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.CertificateId)
                    .HasConstraintName("FK_Exam_Certificate");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Exams)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Exam_Currency");
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Expenses_Employee");

                entity.HasOne(d => d.ExpenseTypes)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypesId)
                    .HasConstraintName("FK_Expenses_ExpenseTypes");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("Experience");

                entity.Property(e => e.CompanyName).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Function).HasMaxLength(225);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(225);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Experience_Employee");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("Family");

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Insured).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Family_Employee");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("Function");

                entity.Property(e => e.Complex).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.ToTable("Holiday");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.New).HasMaxLength(225);

                entity.Property(e => e.Old).HasMaxLength(225);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Holidays)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Holiday_Employee");
            });

            modelBuilder.Entity<HolidayEmployeeDay>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HolidayEmployeeDays)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_HolidayEmployeeDays_Employee");
            });

            modelBuilder.Entity<HolidayWait>(entity =>
            {
                entity.ToTable("HolidayWait");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.HolidayWaits)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_HolidayWait_Employee");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Image_Employee");
            });

            modelBuilder.Entity<OverTime>(entity =>
            {
                entity.ToTable("OverTime");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateForm).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.DocumentName).HasMaxLength(225);

                entity.Property(e => e.DocumentType).HasMaxLength(225);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OverTimes)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_OverTime_Employee");
            });

            modelBuilder.Entity<OvertimePay>(entity =>
            {
                entity.ToTable("OvertimePay");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.OvertimePays)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_OvertimePay_Employee");
            });

            modelBuilder.Entity<PayAbsence>(entity =>
            {
                entity.ToTable("PayAbsence");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PayAbsences)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PayAbsence_Employee");
            });

            modelBuilder.Entity<PersonalReason>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PersonalReasons)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_PersonalReasons_Employee");
            });

            modelBuilder.Entity<ReligiousHoliday>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ReligiousHolidays)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_ReligiousHolidays_Employee");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Scoring>(entity =>
            {
                entity.ToTable("Scoring");

                entity.Property(e => e.By).HasMaxLength(100);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.DateOfFirstConversation).HasColumnType("datetime");

                entity.Property(e => e.FinalDate).HasColumnType("datetime");

                entity.Property(e => e.FirstQuarterDate).HasColumnType("datetime");

                entity.Property(e => e.FirstQuarterPlanDate).HasColumnType("datetime");

                entity.Property(e => e.MarkFinal).HasMaxLength(50);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.SecondQuarterDate).HasColumnType("datetime");

                entity.Property(e => e.SecondQuarterPlanDate).HasColumnType("datetime");

                entity.Property(e => e.ThirdQuarterDate).HasColumnType("datetime");

                entity.Property(e => e.ThirdQuarterPlanDate).HasColumnType("datetime");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Scorings)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Scoring_Department");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Scorings)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Scoring_Employee");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.Scorings)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("FK_Scoring_Work");
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.ToTable("Seminar");

                entity.Property(e => e.Address).HasMaxLength(225);

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Seminars)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_Seminar_Currency");
            });

            modelBuilder.Entity<SeminarOutlay>(entity =>
            {
                entity.ToTable("SeminarOutlay");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.HasOne(d => d.Seminar)
                    .WithMany(p => p.SeminarOutlays)
                    .HasForeignKey(d => d.SeminarId)
                    .HasConstraintName("FK_SeminarOutlay_Seminar");
            });

            modelBuilder.Entity<SheetList>(entity =>
            {
                entity.ToTable("SheetList");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.SheetLists)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_SheetList_Department");
            });

            modelBuilder.Entity<SheetListUnlock>(entity =>
            {
                entity.ToTable("SheetListUnlock");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.UnlockDate).HasColumnType("datetime");

                entity.HasOne(d => d.SheetList)
                    .WithMany(p => p.SheetListUnlocks)
                    .HasForeignKey(d => d.SheetListId)
                    .HasConstraintName("FK_SheetListUnlock_SheetList");

                entity.HasOne(d => d.UnlockByNavigation)
                    .WithMany(p => p.SheetListUnlocks)
                    .HasForeignKey(d => d.UnlockBy)
                    .HasConstraintName("FK_SheetListUnlock_Employee");
            });

            modelBuilder.Entity<SickLeave>(entity =>
            {
                entity.ToTable("SickLeave");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SickLeaves)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_SickLeave_Employee");
            });

            modelBuilder.Entity<SickLeaveDocument>(entity =>
            {
                entity.ToTable("SickLeaveDocument");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.SickLeave)
                    .WithMany(p => p.SickLeaveDocuments)
                    .HasForeignKey(d => d.SickLeaveId)
                    .HasConstraintName("FK_SickLeaveDocument_SickLeave");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("Vendor");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(225);
            });

            modelBuilder.Entity<Work>(entity =>
            {
                entity.ToTable("Work");

                entity.Property(e => e.Complex).HasMaxLength(225);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Modfied).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Qualifications).HasMaxLength(225);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
