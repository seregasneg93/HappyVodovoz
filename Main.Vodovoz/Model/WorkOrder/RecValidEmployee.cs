using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Interface;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.WorkDB.OrderDb;

namespace Main.Vodovoz.Model.WorkOrder
{
    public class RecValidEmployee
    {
        AddOrdeer _addOrder = new();

        public async Task<List<EmployeePresenter>> ReceiveValidEmployeeAsync(OrderPresenter selectedOrder)
        {
            IOrder employee = _addOrder;

            return await employee.ReceiveValidEmploueePresenterAsync(selectedOrder);
        }
    }
}
