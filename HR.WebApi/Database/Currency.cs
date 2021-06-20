using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Currency
    {
        public Currency()
        {
            Certificates = new HashSet<Certificate>();
            Exams = new HashSet<Exam>();
            Seminars = new HashSet<Seminar>();
        }

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

        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Seminar> Seminars { get; set; }
    }
}
