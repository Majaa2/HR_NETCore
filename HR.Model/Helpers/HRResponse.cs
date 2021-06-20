using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Model.Helpers
{
    public class HRResponse
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public List<ResponseError> ErrorList { get; set; }
        public dynamic Result { get; set; } 
    }
}
