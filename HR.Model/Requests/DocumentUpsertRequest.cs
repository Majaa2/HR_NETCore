using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class DocumentUpsertRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? Size { get; set; }
        public byte[] Document1 { get; set; }
        public DateTime? Upload { get; set; }
        public string Group { get; set; }
        public string Subgroup { get; set; }
        public string Path { get; set; }
        public DateTime? ValidTo { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
