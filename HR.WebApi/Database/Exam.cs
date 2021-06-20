using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Exam
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public int? CertificateId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Certificate Certificate { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
