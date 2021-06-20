using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class CompetitionCompetitorUpsertRequest
    {
        public int Id { get; set; }
        public DateTime? Received { get; set; }
        public bool? PassFirstRound { get; set; }
        public DateTime? PassDateFirstRound { get; set; }
        public bool? PassSecondRound { get; set; }
        public DateTime? PassDateSecondRound { get; set; }
        public int? CompetitionId { get; set; }
        public int? CompetitorId { get; set; }
        public int? WorkId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
