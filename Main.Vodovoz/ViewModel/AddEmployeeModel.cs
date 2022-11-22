using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkDivision;
using Main.Vodovoz.Model.WorkEmployee;
using Main.Vodovoz.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Vododvoz.Data.Data.Entyties;
using Vodovoz.Services.Interface;
using Vodovoz.Services.Presenters;
using Vodovoz.Services.ViewModelBases;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.ViewModel
{
    public class AddEmployeeModel : ViewModelBase
    {

        RecDevision _recDevision = new();
        Action _addNewEmployee;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropeertyChanged();
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropeertyChanged();
            }
        }
        private string _patronymuc;
        public string Patronymuc
        {
            get => _patronymuc;
            set
            {
                _patronymuc = value;
                OnPropeertyChanged();
            }
        }

        private DateTime _dateBirth = DateTime.Now;
        public DateTime DateBirth
        {
            get => _dateBirth;
            set
            {
                _dateBirth = value;
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

        private List<string> _collectionsDevisionPresenter;
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


        public AddEmployeeModel(Action addNewEmployee)
        {
            _addNewEmployee = addNewEmployee;
            _ = StartResourcesAsync();

            AddEmployeesCommand = new LambdaCommand(OnAddEmployeesCommand, CanAddEmployeesCommand);
        }

        public ICommand AddEmployeesCommand { get; }
        private bool CanAddEmployeesCommand(object p) => true;
        private async void OnAddEmployeesCommand(object p)
        {
            AddEmployee addEmployee = new();

            var resultAssNewEmployee = await addEmployee.AddNewEmployee(Name,Surname,Patronymuc,DateBirth,SelectedGender,SelectedDivision);

            MessageBox.Show(resultAssNewEmployee);
            _addNewEmployee.Invoke();         
        }

        async Task StartResourcesAsync()
        {
            await Task.Run(async () =>
            {
                CollectionsDevisionPresenter = await _recDevision.ReceiveDivisionsPresenterAsync().ConfigureAwait(false);
            }).ConfigureAwait(false);
        }
    }
}
