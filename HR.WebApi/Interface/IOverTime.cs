using HR.Model.Helpers;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IOverTime
    {
        HRResponse Get();
        HRResponse GetById(int id);
        HRResponse Add(OverTimeUpsertRequest overtimeToModify);
        HRResponse Update(OverTimeUpsertRequest overtimeToModify);
        HRResponse Update(Model.OverTime overtimeToModify);
        HRResponse Delete(int id);
    }
}
