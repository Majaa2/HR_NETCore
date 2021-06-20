using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class CertificateUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!", AllowEmptyStrings = false)]
        public string Name { get; set; }
        public double? PriceTotal { get; set; }

        [Required(ErrorMessage = "Code is required!", AllowEmptyStrings = false)]
        public string Code { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public int? Valid { get; set; }
        public DateTime? EmployeeCertificateDeadlinDate { get; set; }
        public DateTime? EmployeeCertificateExpires { get; set; }
        public DateTime? EmployeeCertificateAllotDate { get; set; }
        public string EmployeeCertificateStatus { get; set; }
        public DateTime? EmployeeCertificateComplete { get; set; }
        public int? VendorId { get; set; }
        public int? EmployeeId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
