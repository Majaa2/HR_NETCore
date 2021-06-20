using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class SheetList
    {
        public SheetList()
        {
            EmployeeSheetLists = new HashSet<EmployeeSheetList>();
            SheetListUnlocks = new HashSet<SheetListUnlock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public string Status { get; set; }
        public int? DepartmentId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<EmployeeSheetList> EmployeeSheetLists { get; set; }
        public virtual ICollection<SheetListUnlock> SheetListUnlocks { get; set; }
    }
}
