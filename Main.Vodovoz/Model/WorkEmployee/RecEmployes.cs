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
    public class RecEmployes
    {
        AddEmployees _addEmployee = new();

        public async Task<List<EmployeePresenter>> ReceiveAllEmployeePresenters ()
        {
            IEmployee employee = _addEmployee;

            return await employee.ReceiveAllEmployeePresentersAsync();
        }
    }
}
 