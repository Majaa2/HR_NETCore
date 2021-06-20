using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Branch
    {
        public Branch()
        {
            Debts = new HashSet<Debt>();
            EmployeeBranches = new HashSet<EmployeeBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int? Number { get; set; }
        public int? CityId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Debt> Debts { get; set; }
        public virtual ICollection<EmployeeBranch> EmployeeBranches { get; set; }
    }
}
