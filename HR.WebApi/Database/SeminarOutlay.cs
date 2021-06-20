using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class SeminarOutlay
    {
        public int Id { get; set; }
        public int? SeminarId { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
