using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Certificate
    {
        public Certificate()
        {
            Exams = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? PriceTotal { get; set; }
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

        public virtual Currency Currency { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}
