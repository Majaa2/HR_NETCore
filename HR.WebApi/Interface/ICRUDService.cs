using HR.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface ICRUDService<T, TSearch, TInsert, TUpdate> : IService<T, TSearch>
    {
        HRResponse Insert(TInsert request);
        HRResponse Update(int id, TUpdate request);
        HRResponse Delete(int id);
    }
}



