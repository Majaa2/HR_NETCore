using HR.Model.Helpers;
using HR.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HR.WebApi.Interface
{
    public interface IEmployee
    {
        HRResponse Get();
        HRResponse GetById(int id);
        HRResponse Add(EmployeeUpsertRequest employeeToModify);
        HRResponse Update(EmployeeUpsertRequest employeeToModify);
        HRResponse Update(Model.Employee employeeToModify);
        HRResponse CreateAccount(EmployeeUpsertRequest employeeToModify, List<int> roleList);
        HRResponse Delete(int id);

        //model.BdUser ChangePassword(ChangePasswordUpsertRequest request);

    }
}
