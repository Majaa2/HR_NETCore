using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class CurrencyUpsertRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CodeAlfa { get; set; }
        public string CodeNum { get; set; }
        public string Symbol { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }
    }
}
