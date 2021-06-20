using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model
{
    public class SheetListUnlock
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTime? UnlockDate { get; set; }
        public int? UnlockBy { get; set; }
        public int? SheetListId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual SheetList SheetList { get; set; }
        public virtual Employee UnlockByNavigation { get; set; }
    }
}
