using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Experience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
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

        public virtual Employee Employee { get; set; }
    }
}
