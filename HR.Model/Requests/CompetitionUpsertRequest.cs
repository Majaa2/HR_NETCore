using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class CompetitionUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required!", AllowEmptyStrings = false)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Title is required!", AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Start date is required!", AllowEmptyStrings = false)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End date is required!", AllowEmptyStrings = false)]
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

    }
}
