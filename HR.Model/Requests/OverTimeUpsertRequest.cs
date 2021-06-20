using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class OverTimeUpsertRequest
    {
        public int Id { get; set; }
        public DateTime? DateForm { get; set; }
        public DateTime? DateTo { get; set; }
        public string Notes { get; set; }
        public int? DurationHours { get; set; }
        public int? DurationMinutes { get; set; }
        public int? Status { get; set; }
        public byte[] Document { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentPath { get; set; }
        public int? TotalHours { get; set; }
        public int? TotalHoursAvailable { get; set; }
        public int? TotalHoursUsed { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
