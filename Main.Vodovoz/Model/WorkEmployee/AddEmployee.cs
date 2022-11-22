using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Interface;
using Vodovoz.Services.WorkDB.EmployeeDB;

namespace Main.Vodovoz.Model.WorkEmployee
{
    public class AddEmployee
    {
        AddEmployees _addEmployee = new();
        public async Task<string> AddNewEmployee(string name,string surName,string patronymis,DateTime dateBirth,string gender,string nameDeviison)
        {
            IEmployee employee = _addEmployee;

            string resultAddNewEmployee = await employee.AddNewEmployeeAsync(name,surName,patronymis,dateBirth,gender, nameDeviison);

            return resultAddNewEmployee;
        }
    }
}
