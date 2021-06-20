using HR.Model.Helpers;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface ISickLeaveDocument
    {
        HRResponse Get();
        HRResponse GetById(int id);
        HRResponse Add(SickLeaveDocumentUpsertRequest sickLeaveDocumentToModify);
        HRResponse Update(SickLeaveDocumentUpsertRequest sickLeaveDocumentToModify);
        HRResponse Update(Model.SickLeaveDocument sickLeaveDocumentToModify);
        HRResponse Delete(int id);

    }
}
