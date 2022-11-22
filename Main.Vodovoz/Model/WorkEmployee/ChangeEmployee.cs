using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Interface;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.WorkDB.EmployeeDB;

namespace Main.Vodovoz.Model.WorkEmployee
{
    public class ChangeEmployee
    {
        AddEmployees _addEmployee = new();
        public async Task<string> ChangeSelectedEmployee(EmployeePresenter employeePresenter,string nameDevision)
        {
            IEmployee employee = _addEmployee;

            string resultAddNewEmployee = await employee.ChangeEmployee(employeePresenter, nameDevision);

            return resultAddNewEmployee;
        }
    }
}
