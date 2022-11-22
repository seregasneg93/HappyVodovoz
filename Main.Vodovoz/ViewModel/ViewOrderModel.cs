using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.ViewModelBases;

namespace Main.Vodovoz.ViewModel
{
    public class ViewOrderModel : ViewModelBase
    {
        private OrderPresenter _selectedOrder;
        public OrderPresenter SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropeertyChanged();
            }
        }

        public ViewOrderModel(OrderPresenter selectedOrder)
        {
            SelectedOrder = selectedOrder;
        }
    }
}
