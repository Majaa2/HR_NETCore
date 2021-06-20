using HR.Model.Helpers;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IImage
    {
        HRResponse Get();
        HRResponse GetById(int id);
        HRResponse Add(ImageUpsertRequest imageToModify);
        HRResponse Update(ImageUpsertRequest imageToModify);
        HRResponse Update(Model.Image imageToModify);
        HRResponse Delete(int id);
    }
}
