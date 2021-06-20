using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IEmail
    {
        bool Send(string[] to, string subject, string body, bool isHtml);

    }
}
