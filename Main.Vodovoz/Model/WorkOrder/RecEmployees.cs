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
    public class RecEmployees
    {
        AddOrdeer _addOrder = new();

        public async Task<List<OrderPresenter>> ReceiveAllPresentersOrderCollectionsAsync()
        {
            IOrder employee = _addOrder;

            return await employee.ReceiveAllOredersPresentersSync();
        }
    }
}
