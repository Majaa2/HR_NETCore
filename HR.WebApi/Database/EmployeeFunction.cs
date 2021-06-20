﻿using System;
using System.Collections.Generic;

#nullable disable

namespace HR.WebApi.Database
{
    public partial class EmployeeFunction
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? FunctionId { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Function Function { get; set; }
    }
}
