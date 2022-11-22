using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Presenters;

namespace Vodovoz.Services.Interface
{
    public interface IEmployee
    {
        Task<string> AddNewEmployeeAsync(string name, string surName, string patronymis, DateTime dateBirth,string gender, string nameDevision);
        Task<List<EmployeePresenter>> ReceiveAllEmployeePresentersAsync();
        Task<string> ChangeEmployee(EmployeePresenter employeePresenter, string nameDevision);
        Task<string> DeleteEmployeeAsync(int idEmployee);
    }
}
