using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Requests
{
    public class EmployeeAccountUpsertRequest
    {
        public EmployeeUpsertRequest employee { get; set; }
        public List<int> roleList { get; set; }
    }
}
