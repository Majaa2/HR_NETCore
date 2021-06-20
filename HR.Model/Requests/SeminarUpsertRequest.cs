using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class SeminarUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required!", AllowEmptyStrings = false)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Name is required!", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Start date is required!", AllowEmptyStrings = false)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "End date is required!", AllowEmptyStrings = false)]
        public DateTime? EndDate { get; set; }
        public int? Count { get; set; }

        [Required(ErrorMessage = "Price is required!", AllowEmptyStrings = false)]
        [RegularExpression("[0-9]+", ErrorMessage = "0-9")]
        public double? Price { get; set; }

        [RegularExpression("[0-9]+", ErrorMessage = "0-9")]
        [Required(ErrorMessage = "Address is required!", AllowEmptyStrings = false)]
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

    }
}
