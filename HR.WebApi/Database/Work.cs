using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Work
    {
        public Work()
        {
            CompetitionCompetitors = new HashSet<CompetitionCompetitor>();
            Competitions = new HashSet<Competition>();
            Employees = new HashSet<Employee>();
            Scorings = new HashSet<Scoring>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearsNeeded { get; set; }
        public int? Quotientint { get; set; }
        public string Complex { get; set; }
        public string Qualifications { get; set; }
        public int? Number { get; set; }
        public string Conditions { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<CompetitionCompetitor> CompetitionCompetitors { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Scoring> Scorings { get; set; }
    }
}
