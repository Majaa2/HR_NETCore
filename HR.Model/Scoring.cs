using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Scoring
    {
        public int Id { get; set; }
        public string By { get; set; }
        public string GoalsNext12Month { get; set; }
        public DateTime? DateOfFirstConversation { get; set; }
        public string NeededEducation { get; set; }
        public DateTime? FirstQuarterPlanDate { get; set; }
        public DateTime? FirstQuarterDate { get; set; }
        public string FirstQuarterNotes { get; set; }
        public string FirstQuarterEduNotes { get; set; }
        public DateTime? SecondQuarterPlanDate { get; set; }
        public DateTime? SecondQuarterDate { get; set; }
        public string SecondQuarterNotes { get; set; }
        public string SecondQuarterEduNotes { get; set; }
        public DateTime? ThirdQuarterPlanDate { get; set; }
        public DateTime? ThirdQuarterDate { get; set; }
        public string ThirdQuarterNotes { get; set; }
        public string ThirdQuarterEduNotes { get; set; }
        public string RewardingEmployee { get; set; }
        public string MarkFinal { get; set; }
        public string MarkFinalNotes { get; set; }
        public DateTime? FinalDate { get; set; }
        public int? Year { get; set; }
        public int? EmployeeId { get; set; }
        public int? WorkId { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Work Work { get; set; }
    }
}
