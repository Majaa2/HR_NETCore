using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class CompetitorUpsertRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string DrivingLicence { get; set; }

        [RegularExpression("^[0-9]{9,16}$", ErrorMessage = "Minimum 9 numbers!")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Qualificaations { get; set; }
        public string Profession { get; set; }
        public string SpecialKnowledgeAndSkills { get; set; }
        public DateTime? DateOfRegistration { get; set; }
        public int? CityId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
