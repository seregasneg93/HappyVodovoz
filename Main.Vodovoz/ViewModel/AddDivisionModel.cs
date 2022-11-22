using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkDivision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Vodovoz.Services.ViewModelBases;
using Vodovoz.Services.WorkDB.DivisionDb;

namespace Main.Vodovoz.ViewModel
{
    public class AddDivisionModel : ViewModelBase
    {
        AddNewDivision _addDivision = new();
        Action _methodAdd;
        private string _nameDivision;
        public string NameDivision
        {
            get => _nameDivision;
            set
            {
                _nameDivision = value;
                OnPropeertyChanged();
            }
        }

        public AddDivisionModel(Action methodAdd)
        {
            _methodAdd = methodAdd;

            AddDivisionsCommand = new LambdaCommand(OnAddDivisionsCommand, CanAddDivisionsCommand);
        }

        public ICommand AddDivisionsCommand { get; }
        private bool CanAddDivisionsCommand(object p) => true;
        private async void OnAddDivisionsCommand(object p)
        {
            await AddDivisionAsync().ConfigureAwait(false);
        }

        private async Task AddDivisionAsync()
        {
            await Task.Run(async () =>
                {
                    MessageBox.Show(await _addDivision.AddNewDivFromDbAsync(NameDivision).ConfigureAwait(false));
                }).ConfigureAwait(false);

            _methodAdd.Invoke();
        }
    }
}
