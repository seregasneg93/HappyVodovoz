using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkEmployee;
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
    public class ViewEmployeeModel : ViewModelBase
    {
        RecEmployes _recEmployes = new();
        DelEmployee _delEmployee;

        private List<EmployeePresenter> _collectionsEmployeePresenter;
        public List<EmployeePresenter> CollectionsEmployeePresenter
        {
            get => _collectionsEmployeePresenter;
            set
            {
                _collectionsEmployeePresenter = value;
                OnPropeertyChanged();
            }
        }

        private EmployeePresenter _selectedEmpoloyeePresenter;
        public EmployeePresenter SelectedEmpoloyeePresenter
        {
            get => _selectedEmpoloyeePresenter;
            set
            {
                _selectedEmpoloyeePresenter = value;
                OnPropeertyChanged();
            }
        }

        public ViewEmployeeModel()
        {
            StartResources();

            OPenAddEmployeesCommand = new LambdaCommand(OnOPenAddEmployeesCommand, CanOPenAddEmployeesCommand);
            OPenCurrentEmployeesCommand = new LambdaCommand(OnOPenCurrentEmployeesCommand, CanOPenCurrentEmployeesCommand);
            DeleteEmpoloyeeCommand = new LambdaCommand(OnDeleteEmpoloyeeCommand, CanDeleteEmpoloyeeCommand); //
        }

        public ICommand OPenAddEmployeesCommand { get; }
        private bool CanOPenAddEmployeesCommand(object p) => true;
        private void OnOPenAddEmployeesCommand(object p)
        {
            AddEmployeeWindow viewAddEmployee = new(ActionAddNewEmployee);
            viewAddEmployee.Show();
        }

        public ICommand OPenCurrentEmployeesCommand { get; }
        private bool CanOPenCurrentEmployeesCommand(object p)
        {
            if (SelectedEmpoloyeePresenter is null)
                return false;
            else return true;
        }
        private void OnOPenCurrentEmployeesCommand(object p)
        {
            CurrentEmployeeWindow viewCurrentEmployee = new(ActionChangeEmployee, SelectedEmpoloyeePresenter);
            viewCurrentEmployee.ShowDialog();
        }
        public ICommand DeleteEmpoloyeeCommand { get; }
        private bool CanDeleteEmpoloyeeCommand(object p)
        {
            if (SelectedEmpoloyeePresenter is null)
                return false;
            else return true;
        }
        private async void OnDeleteEmpoloyeeCommand(object p)
        {
            _delEmployee = new();

            if (MessageBox.Show("Вы действительно хотите удалить работника?",
          "Удаление!",
          MessageBoxButton.YesNo,
          MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string resultDelDevision = await _delEmployee.DeleteSelectedEmployeeAsync(SelectedEmpoloyeePresenter.Id);

                MessageBox.Show(resultDelDevision);

                if (resultDelDevision.Equals("Работник успешно удален"))
                {
                    CollectionsEmployeePresenter.Remove(SelectedEmpoloyeePresenter);
                    RefreshColletions();
                }
            }
        }

        void StartResources()
        {
          _ = LoadPresenterEmployeeasync();
        }

        void ActionAddNewEmployee()
        {
            RefreshColletions();
        }

        void ActionChangeEmployee()
        {
            CollectionsEmployeePresenter = new(CollectionsEmployeePresenter);

        }

        void RefreshColletions()
        {
            _ = LoadPresenterEmployeeasync();
        }

        async Task LoadPresenterEmployeeasync()
        {
            await Task.Run(async () =>
            {
                CollectionsEmployeePresenter = await _recEmployes.ReceiveAllEmployeePresenters();
            }).ConfigureAwait(false);
        }
    }
}
