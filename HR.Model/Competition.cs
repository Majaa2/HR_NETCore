using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Competition
    {
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
    }
}
