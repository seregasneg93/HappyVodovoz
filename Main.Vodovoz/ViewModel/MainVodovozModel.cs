using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkOrder;
using Main.Vodovoz.View;
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
    public class MainVodovozModel : ViewModelBase
    {
        #region Свойства и поля

        RecEmployees _recEmployees = new();
        DelOrder _delOrder;

        private List<OrderPresenter> _ordersColletions = new();
        public List<OrderPresenter> OrdersColletions
        {
            get => _ordersColletions;
            set
            {
                _ordersColletions = value;
                OnPropeertyChanged();
            }
        }

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

        #endregion

        #region Конструктор

        public MainVodovozModel()
        {
            _ =  StartResourcesAsync();


            OPenOrderCommand = new LambdaCommand(OnOPenOrderCommand, CanOPenOrderCommand); //
            AddOrderCommand = new LambdaCommand(OnAddOrderCommand, CanAddOrderCommand); //
            CurrentOrderCommand = new LambdaCommand(OnCurrentOrderCommand, CanCurrentOrderCommand); //
            DeleteOrderCommand = new LambdaCommand(OnDeleteOrderCommand, CanDeleteOrderCommand); //

            OPenAllEmployeesCommand = new LambdaCommand(OnOPenAllEmployeesCommand, CanOPenAllEmployeesCommand); //

            OPenAllDivisionsCommand = new LambdaCommand(OnOPenAllDivisionsCommand, CanOPenAllDivisionsCommand); //
        }

        #endregion

        #region Команды

        public ICommand OPenOrderCommand { get; }
        private bool CanOPenOrderCommand(object p)
        {
            if (SelectedOrder is null)
                return false;
            else return true;
        }
        private void OnOPenOrderCommand(object p)
        {
            ViewOrderWindow viewAllOrders = new(SelectedOrder);
            viewAllOrders.Show();
        }
        public ICommand AddOrderCommand { get; }
        private bool CanAddOrderCommand(object p) => true;
        private void OnAddOrderCommand(object p)
        {
            AddOrderWindow viewAddOrder = new(ActionNewOrder);
            viewAddOrder.Show();
        }
        public ICommand CurrentOrderCommand { get; }
        private bool CanCurrentOrderCommand(object p)
        {
            if (SelectedOrder is null)
                return false;
            else return true;
        }
        private void OnCurrentOrderCommand(object p)
        {
            CurrentOrderWindow viewCurrentOrder = new(SelectedOrder, ChangeOrder);
            viewCurrentOrder.Show();
        }
        public ICommand DeleteOrderCommand { get; }
        private bool CanDeleteOrderCommand(object p)
        {

            if (SelectedOrder is null)
                return false;
            else return true;

        }
        private async void OnDeleteOrderCommand(object p)
        {
            _delOrder = new();

            if (MessageBox.Show("Вы действительно хотите удалить заказ?",
          "Удаление!",
          MessageBoxButton.YesNo,
          MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string resultDelDevision = await _delOrder.DeleteOrderAsync(SelectedOrder.Id);

                MessageBox.Show(resultDelDevision);

                if (resultDelDevision.Equals("Данный заказ удален"))
                {
                    OrdersColletions.Remove(SelectedOrder);
                    RefreshCollections();
                }
            }
        }

        public ICommand OPenAllEmployeesCommand { get; }
        private bool CanOPenAllEmployeesCommand(object p) => true;
        private void OnOPenAllEmployeesCommand(object p)
        {
            ViewEmployeeWindow viewAllEmployee = new();
            viewAllEmployee.Show();
        }


        public ICommand OPenAllDivisionsCommand { get; }
        private bool CanOPenAllDivisionsCommand(object p) => true;
        private void OnOPenAllDivisionsCommand(object p)
        {
            ViewDevesionWindow viewAllDisions = new();
            viewAllDisions.Show();
        }
        #endregion

        #region Методы

        async Task StartResourcesAsync()
        {
            await Task.Run(async () =>
            {
                OrdersColletions = await _recEmployees.ReceiveAllPresentersOrderCollectionsAsync();
            }).ConfigureAwait(false);
        }

        void ActionNewOrder()
        {
            _ = StartResourcesAsync();

            RefreshCollections();
        }

        void RefreshCollections()
        {
            OrdersColletions = new(OrdersColletions);
        }

        void ChangeOrder()
        {
            _ = StartResourcesAsync();

            RefreshCollections();
        }
        #endregion

    }
}
