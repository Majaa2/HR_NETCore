using HR.Model.Helpers;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IDocument
    {
        HRResponse Get();
        HRResponse GetById(int id);
        HRResponse Add(DocumentUpsertRequest DocumentToModify);
        HRResponse Update(DocumentUpsertRequest DocumentToModify);
        HRResponse Update(Model.Document DocumentToModify);
        HRResponse Delete(int id);

    }
}
