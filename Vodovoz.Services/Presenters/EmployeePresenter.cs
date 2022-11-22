using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;

namespace Vodovoz.Services.Presenters
{
    public class EmployeePresenter
    {
        public EmployeePresenter(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            SurName = employee.SurName;
            Patronymic = employee.Patronymic;
            DateBirth = employee.DateBirth;
            Gender = employee.Gender;
            OrderPresenters = new();

            if(employee.Orders != null)
                foreach (var order in employee.Orders)
                    OrderPresenters.Add(new OrderPresenter(order));

            if(employee.Devision != null)
               Devision = new DivisionPresenter(employee.Devision);
        }

        public EmployeePresenter(EmployeePresenter employeePresenter)
        {
            Id = employeePresenter.Id;
            Name = employeePresenter.Name;
            SurName = employeePresenter.SurName;
            Patronymic = employeePresenter.Patronymic;
            DateBirth = employeePresenter.DateBirth;
            Gender = employeePresenter.Gender;
            OrderPresenters = new();

            if (employeePresenter.OrderPresenters != null)
                foreach (var order in employeePresenter.OrderPresenters)
                    OrderPresenters.Add(new OrderPresenter(order));

            if (employeePresenter.Devision != null)
                Devision = new DivisionPresenter(employeePresenter.Devision);
        }

        public EmployeePresenter()
        {

        }   

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public bool IsOrder { get; set; }
        public List<OrderPresenter> OrderPresenters { get; set; }
        public DivisionPresenter Devision { get; set; }
    }
}
