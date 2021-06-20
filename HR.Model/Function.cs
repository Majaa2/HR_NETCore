using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Function
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearsNeeded { get; set; }
        public string Complex { get; set; }
        public int? Number { get; set; }
        public int? Level { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }
    }
}
