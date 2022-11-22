using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.ViewModelBases;

namespace Main.Vodovoz.ViewModel
{
    public class CurrentOrderModel : ViewModelBase
    {
        Action _change;

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

        public CurrentOrderModel(OrderPresenter selectedOrder, Action change)
        {
            _ = StartResourcesAsync(selectedOrder);

            RefreshCurrentOrderCommand = new LambdaCommand(OnRefreshCurrentOrderCommand, CanRefreshCurrentOrderCommand);
            _change = change;
        }

        public ICommand RefreshCurrentOrderCommand { get; }
        private bool CanRefreshCurrentOrderCommand(object p) => true;
        private async void OnRefreshCurrentOrderCommand(object p)
        {
            CurrentOrder currentOrder = new();
            string result = "";
            await Task.Run(async () =>
            {
                 result = await currentOrder.CurrentOrderAsync(SelectedOrder);

                _change.Invoke();

            }).ConfigureAwait(false);

            MessageBox.Show(result);
        }

        async Task StartResourcesAsync(OrderPresenter selectedOrder)
        {
            RecValidEmployee recValidEmployee = new();
            OrderPresenter orderPresenter = new();

            await Task.Run(async () =>
            {
                SelectedOrder = new OrderPresenter(selectedOrder);
                orderPresenter = SelectedOrder;
                orderPresenter.EmployeePresenters.Clear();

                orderPresenter.EmployeePresenters = await recValidEmployee.ReceiveValidEmployeeAsync(selectedOrder);

                SelectedOrder = orderPresenter;
            }).ConfigureAwait(false);
        }
    }
}
