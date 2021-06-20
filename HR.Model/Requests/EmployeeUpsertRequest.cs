using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class EmployeeUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Firstname is required!", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required!", AllowEmptyStrings = false)]
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string UserName { get; set; }

        //[Display(Name = "Password", ResourceType = typeof(System.Resources.Default))]

        public string Password { get; set; }

        [Required(ErrorMessage = "JMBG is required!", AllowEmptyStrings = false)]
        [RegularExpression("^[0-9]{13}$", ErrorMessage = "13 numbers!")]
        public string Jmbg { get; set; }

        [Required(ErrorMessage = "IDCard is required!", AllowEmptyStrings = false)]
        public string IdCard { get; set; }

        [Required(ErrorMessage = "Sex is required!", AllowEmptyStrings = false)]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Marriage status is required!", AllowEmptyStrings = false)]
        public string MarriageStatus { get; set; }

        [Required(ErrorMessage = "Driving licence is required!", AllowEmptyStrings = false)]
        public string DrivingLicence { get; set; }
        public string CategoryDl { get; set; }

        [Required(ErrorMessage = "Birth date is required!", AllowEmptyStrings = false)]
        public DateTime? BirthDate { get; set; }


        [Required(ErrorMessage = "Birth place is required!", AllowEmptyStrings = false)]
        public string BirthPlace { get; set; }
        public string BirthTownship { get; set; }

        [Required(ErrorMessage = "Father name is required!", AllowEmptyStrings = false)]
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }

        [Required(ErrorMessage = "Phone number is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^[0-9+ ]{9,16}$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mobile phone is required!", AllowEmptyStrings = false)]
        [RegularExpression("^[0-9+ ]{9,16}$", ErrorMessage = "Minimum 9 numbers")]
        public string MobilePhone { get; set; }


        [Required(ErrorMessage = "E-mail is required!", AllowEmptyStrings = false)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Qualification is required!", AllowEmptyStrings = false)]
        public string Qualifications { get; set; }

        [Required(ErrorMessage = "Profession is required!", AllowEmptyStrings = false)]
        public string Profession { get; set; }

        [Required(ErrorMessage = "Edu institution is required!", AllowEmptyStrings = false)]
        public string EduInstitution { get; set; }

        [Required(ErrorMessage = "Address is required!", AllowEmptyStrings = false)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Place is required!", AllowEmptyStrings = false)]
        public string Place { get; set; }
        public int? ExperienceCount { get; set; }

        [Required(ErrorMessage = "Citizenship is required!", AllowEmptyStrings = false)]
        public string Citizenship { get; set; }

        [Required(ErrorMessage = "Nationality is required!", AllowEmptyStrings = false)]
        public string Nationality { get; set; }
        public string SpecialKnowledgeAndSkills { get; set; }
        public string Disability { get; set; }
        public string EntityOfResidence { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string BloodType { get; set; }
        public string Code { get; set; }
        public string Points { get; set; }

        [Required(ErrorMessage = "City is required!", AllowEmptyStrings = false)]
        public int? CityId { get; set; }

        [Required(ErrorMessage = "Work is required!", AllowEmptyStrings = false)]
        public int? WorkId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        [Required(ErrorMessage = "Education category is required!", AllowEmptyStrings = false)]
        public int? EducationCategoryId { get; set; }
        public List<Branch> Branches { get; set; }
        public List<Department> Departments { get; set; }
        public List<Function> Functions { get; set; }
        public List<Role> Roles { get; set; }
        public List<Seminar> Seminars { get; set; }
        public List<SheetList> SheetLists { get; set; }
    }
}
