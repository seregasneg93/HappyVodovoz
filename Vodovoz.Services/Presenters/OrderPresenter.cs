using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vododvoz.Data.Data.Entyties;

namespace Vodovoz.Services.Presenters
{
    public class OrderPresenter
    {
        public OrderPresenter(Order order, List<Employee> employees = null)
        {
            Id = order.Id;
            NameOrder = order.NameOrder;
            EmployeePresenters = new();

            if (employees != null)
            {
                foreach (var emp in employees)
                    EmployeePresenters.Add(new EmployeePresenter(emp));
            }

        }

        public OrderPresenter(OrderPresenter orderPresenter)
        {
            Id = orderPresenter.Id;
            NameOrder = orderPresenter.NameOrder;
            EmployeePresenters = new();

            foreach (var emp in orderPresenter.EmployeePresenters)
                EmployeePresenters.Add(new EmployeePresenter(emp));

        }

        public OrderPresenter()
        {

        }

        public int Id { get; set; }
        public string NameOrder { get; set; }
        public List<EmployeePresenter> EmployeePresenters { get; set; }
    }
}
