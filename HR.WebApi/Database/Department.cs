using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Department
    {
        public Department()
        {
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
            Scorings = new HashSet<Scoring>();
            SheetLists = new HashSet<SheetList>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Max { get; set; }
        public string Profession { get; set; }
        public string Complex { get; set; }
        public int? Number { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<Scoring> Scorings { get; set; }
        public virtual ICollection<SheetList> SheetLists { get; set; }
    }
}
