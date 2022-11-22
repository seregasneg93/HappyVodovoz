using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkEmployee;
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
    public class AddOrderModel : ViewModelBase
    {
        Action _addNewOrder;
        RecEmployes _recEmployes;
        AddOrder _addOrder;

        private string _nameOrder;
        public string NameOrder
        {
            get => _nameOrder;
            set
            {
                _nameOrder = value;
                OnPropeertyChanged();
            }
        }

        private List<EmployeePresenter> _employeePresenterColleions = new();
        public List<EmployeePresenter> EmployeePresenterColleions
        {
            get => _employeePresenterColleions;
            set
            {
                _employeePresenterColleions = value;
                OnPropeertyChanged();
            }
        }

        public AddOrderModel(Action addNewOrder)
        {
            _addNewOrder = addNewOrder;

            _ = StartResourcesAsync();

            AddNewOrderCommand = new LambdaCommand(OnAddNewOrderCommand, CanAddNewOrderCommand); //
        }


        public ICommand AddNewOrderCommand { get; }
        private bool CanAddNewOrderCommand(object p) => true;
        private async void OnAddNewOrderCommand(object p)
        {
            _addOrder = new();
            string result = "";
            await Task.Run(async () =>
            {
                List<EmployeePresenter> addEmployee = new();

                addEmployee = EmployeePresenterColleions.Where(x => x.IsOrder).ToList();

                result = await _addOrder.AddNewOrderAsync(NameOrder, addEmployee);


            }).ConfigureAwait(false);

            MessageBox.Show(result);

            _addNewOrder.Invoke();
        }

        async Task StartResourcesAsync()
        {
            _recEmployes = new();
            await Task.Run(async () =>
            {
                EmployeePresenterColleions = await _recEmployes.ReceiveAllEmployeePresenters();
            }).ConfigureAwait(false);
        }
    }
}
