using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class ReligiousHolidayUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Date is required!", AllowEmptyStrings = false)]
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
