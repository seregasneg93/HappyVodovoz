using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Interface;
using Vodovoz.Services.WorkDB.OrderDb;

namespace Main.Vodovoz.Model.WorkOrder
{
    public class DelOrder
    {
        AddOrdeer _addOrder = new();

        public async Task<string> DeleteOrderAsync(int idOrder)
        {
            IOrder employee = _addOrder;

            return await employee.DeleteOrderAsync(idOrder);
        }
    }
}
