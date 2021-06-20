using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class ExperienceUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required!", AllowEmptyStrings = false)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Start date is required!", AllowEmptyStrings = false)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End date is required!", AllowEmptyStrings = false)]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Function is required!", AllowEmptyStrings = false)]
        public string Function { get; set; }
        public int? Count { get; set; }
        public string State { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
