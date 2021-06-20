using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Competitor
    {
        public Competitor()
        {
            CompetitionCalls = new HashSet<CompetitionCall>();
            CompetitionCompetitors = new HashSet<CompetitionCompetitor>();
            CompetitorLanguages = new HashSet<CompetitorLanguage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string DrivingLicence { get; set; }
        public string PhoneNumber { get; set; }
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

        public virtual City City { get; set; }
        public virtual ICollection<CompetitionCall> CompetitionCalls { get; set; }
        public virtual ICollection<CompetitionCompetitor> CompetitionCompetitors { get; set; }
        public virtual ICollection<CompetitorLanguage> CompetitorLanguages { get; set; }
    }
}
