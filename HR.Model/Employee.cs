using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
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
        public int? EducationCategoryId { get; set; }
        public List<Branch> Branches {get; set;}
        public List<Department> Departments {get; set;}
        public List<Function> Functions {get; set;}
        public List<Role> Roles {get; set;}
        public List<Seminar> Seminars {get; set;}
        public List<SheetList> SheetLists {get; set; }
        public virtual City City { get; set; }
        public virtual Work Work { get; set; }
        public virtual EducationCategory EducationCategory { get; set; }
    }
}
