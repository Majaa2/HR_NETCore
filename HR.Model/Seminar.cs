using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class Seminar
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Count { get; set; }
        public double? Price { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public double? TotalPrice { get; set; }
        public string Type { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
