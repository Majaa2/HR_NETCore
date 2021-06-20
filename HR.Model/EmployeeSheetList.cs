using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class EmployeeSheetList
    {
        public int Id { get; set; }
        public int? RegularWorkSum { get; set; }
        public int? OvertimeWorkSum { get; set; }
        public int? NightWorkSum { get; set; }
        public int? WorkWeekdaySum { get; set; }
        public int? WorkHolidaysSum { get; set; }
        public int? PaidLeaveSum { get; set; }
        public int? UnpaidLeaveSum { get; set; }
        public int? StimulationSum { get; set; }
        public int? BreastfeedingSum { get; set; }
        public int? PaidUp42DaysSum { get; set; }
        public int? PaidOver42DaysSum { get; set; }
        public int? VacationSum { get; set; }
        public int? HolidaysPaidHolidaysSum { get; set; }
        public int? SuspensionSum { get; set; }
        public int? WorkOnHolidaySum { get; set; }
        public int? OvertimeWorkOf22Sum { get; set; }
        public int? OvertimeWorkOf06Sum { get; set; }
        public int? ExtraordinaryWorkSum { get; set; }
        public int? WorkSecondShiftSum { get; set; }
        public int? DoubleWorkSum { get; set; }
        public int? WorkTurnusSum { get; set; }
        public int? PassiveDutySum { get; set; }
        public int? DifferenceBetweenLessPaidWagesSum { get; set; }
        public int? DifferenceBetweenPaidSalarySum { get; set; }
        public int? RegularWorkOfTraineesSum { get; set; }
        public int? Suspension15Sum { get; set; }
        public int? Suspension30Sum { get; set; }
        public int? EmployeeId { get; set; }
        public int? SheetListId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual SheetList SheetList { get; set; }
    }
}
