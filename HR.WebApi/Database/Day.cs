using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Day
    {
        public int Id { get; set; }
        public int? Name { get; set; }
        public int? RegularWork { get; set; }
        public int? OvertimeWork { get; set; }
        public int? NightWork { get; set; }
        public int? WorkWeekday { get; set; }
        public int? WorkHolidays { get; set; }
        public int? PaidLeave { get; set; }
        public int? UnpaidLeave { get; set; }
        public int? Stimulation { get; set; }
        public int? Breastfeeding { get; set; }
        public int? PaidUp42Days { get; set; }
        public int? PaidOver42Days { get; set; }
        public int? Vacation { get; set; }
        public int? HolidaysPaidHolidays { get; set; }
        public int? Suspension { get; set; }
        public int? WorkOnHoliday { get; set; }
        public int? OvertimeWorkOf22 { get; set; }
        public int? OvertimeWorkOf06 { get; set; }
        public int? ExtraordinaryWork { get; set; }
        public int? WorkSecondShift { get; set; }
        public int? DoubleWork { get; set; }
        public int? WorkTurnus { get; set; }
        public int? PassiveDuty { get; set; }
        public int? DifferenceBetweenLessPaidWages { get; set; }
        public int? DifferenceBetweenPaidSalary { get; set; }
        public int? RegularWorkOfTrainees { get; set; }
        public int? Suspension15 { get; set; }
        public int? Suspension30 { get; set; }
        public int? EmployeeSheetListId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual EmployeeSheetList EmployeeSheetList { get; set; }
    }
}
