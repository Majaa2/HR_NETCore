using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Competition
    {
        public Competition()
        {
            CompetitionCalls = new HashSet<CompetitionCall>();
            CompetitionCompetitors = new HashSet<CompetitionCompetitor>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaxMember { get; set; }
        public string Text { get; set; }
        public DateTime? PassFirstRoundDate { get; set; }
        public int? PassFirstRoundMembers { get; set; }
        public int? PassSecondRoundMembers { get; set; }
        public DateTime? PassSecondRoundDate { get; set; }
        public int? WorkId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Work Work { get; set; }
        public virtual ICollection<CompetitionCall> CompetitionCalls { get; set; }
        public virtual ICollection<CompetitionCompetitor> CompetitionCompetitors { get; set; }
    }
}
