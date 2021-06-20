using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class BranchUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!", AllowEmptyStrings = false)]
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

    }
}
