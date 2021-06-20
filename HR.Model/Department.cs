using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Department
    {
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

    }
}
