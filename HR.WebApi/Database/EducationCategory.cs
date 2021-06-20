using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class EducationCategory
    {
        public EducationCategory()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
