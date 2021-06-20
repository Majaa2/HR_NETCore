using HR.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IService<T, TSearch>
    {
        HRResponse Get(TSearch search);
        HRResponse GetById(int id);
    }
}
