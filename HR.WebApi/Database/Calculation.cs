using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Calculation
    {
        public int Id { get; set; }
        public bool? Processed { get; set; }
        public int? SickLeave { get; set; }
        public int? Vacation { get; set; }
        public int? Overtime { get; set; }
        public int? ByDecision { get; set; }
        public int? BussinessTrip { get; set; }
        public int? StateHoliday { get; set; }
        public int? ReligiousHoliday { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public int? Total { get; set; }
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
