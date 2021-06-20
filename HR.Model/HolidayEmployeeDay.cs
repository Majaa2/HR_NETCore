using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class HolidayEmployeeDay
    {
        public int Id { get; set; }
        public int? HolidayOld { get; set; }
        public int? HolidayNew { get; set; }
        public int? HolidayYear { get; set; }
        public int? HolidayTotal { get; set; }
        public int? HolidayUsed { get; set; }
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
