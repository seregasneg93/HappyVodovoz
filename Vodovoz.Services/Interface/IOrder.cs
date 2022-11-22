using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Presenters;

namespace Vodovoz.Services.Interface
{
    public interface IOrder
    {
        Task<string> AddNewOrderInDbAsync(string nameOrder, List<EmployeePresenter> collectionEmployee);
        Task<List<OrderPresenter>> ReceiveAllOredersPresentersSync();
        Task<string> CurrentOrderAsync(OrderPresenter selectedOrder);
        Task<List<EmployeePresenter>> ReceiveValidEmploueePresenterAsync(OrderPresenter selectedOrder);
        Task<string> DeleteOrderAsync(int idOrder);
    }
}
