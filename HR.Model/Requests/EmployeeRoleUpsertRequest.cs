using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class EmployeeRoleUpsertRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee is required!", AllowEmptyStrings = false)]
        public int? EmployeeId { get; set; }

        [Required(ErrorMessage = "Role is required!", AllowEmptyStrings = false)]
        public int? RoleId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modfied { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public bool? Active { get; set; }

    }
}
