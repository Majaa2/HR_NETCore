﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class Holiday
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Count { get; set; }
        public string Old { get; set; }
        public string New { get; set; }
        public int? EmployeeId { get; set; }
        public string State { get; set; }
        public int? Year { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
