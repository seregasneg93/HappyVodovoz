using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkDivision;
using Main.Vodovoz.Model.WorkEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.ViewModelBases;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.ViewModel
{
    public class CurrentEmployeeModel : ViewModelBase
    {
        Action _changeEpmloyee;
        RecDevision _recDivision;
        ChangeEmployee _changeEmployee;

        private EmployeePresenter _selectedPresenterEmployee;
        public EmployeePresenter SelectedPresenterEmployee
        {
            get => _selectedPresenterEmployee;
            set
            {
                _selectedPresenterEmployee = value;
                OnPropeertyChanged();
            }
        }

        private List<string> _collectionsDevisionPresenter = new();
        public List<string> CollectionsDevisionPresenter
        {
            get => _collectionsDevisionPresenter;
            set
            {
                _collectionsDevisionPresenter = value;
                OnPropeertyChanged();
            }
        }
        private string _selectedDivision;
        public string SelectedDivision
        {
            get => _selectedDivision;
            set
            {
                _selectedDivision = value;
                OnPropeertyChanged();
            }
        }

        private List<string> _collectionsGenderPresenter = new List<string> { "Мужской","Женский"};
        public List<string> CollectionsGenderPresenter
        {
            get => _collectionsGenderPresenter;
            set
            {
                _collectionsGenderPresenter = value;
                OnPropeertyChanged();
            }
        }
        private string _selectedGender;
        public string SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropeertyChanged();
            }
        }

        public CurrentEmployeeModel(Action changeEpmloyee , EmployeePresenter selectedEmployee)
        {
            _changeEpmloyee = changeEpmloyee;
            SelectedPresenterEmployee = selectedEmployee;

            _ = StartResourcesAsync();

            RefreshChamgeEmployeeCommand = new LambdaCommand(OnRefreshChamgeEmployeeCommand, CanRefreshChamgeEmployeeCommand); //
        }

        public ICommand RefreshChamgeEmployeeCommand { get; }
        private bool CanRefreshChamgeEmployeeCommand(object p) => true;
        private async void OnRefreshChamgeEmployeeCommand(object p)
        {
            _changeEmployee = new();

            SelectedPresenterEmployee.Gender = SelectedGender;

            SelectedPresenterEmployee.Devision.NameDevision = SelectedDivision;

            string resultChangeEmployee = await _changeEmployee.ChangeSelectedEmployee(SelectedPresenterEmployee, SelectedDivision);

            MessageBox.Show(resultChangeEmployee);

            _changeEpmloyee.Invoke();
        }


       async Task StartResourcesAsync()
        {
            _recDivision = new();
            await Task.Run(async () =>
            {
                CollectionsDevisionPresenter = await _recDivision.ReceiveDivisionsPresenterAsync();
                SelectedDivision = SelectedPresenterEmployee.Devision.NameDevision;
                SelectedGender = SelectedPresenterEmployee.Gender;
            }).ConfigureAwait(false);
        }
    }
}
