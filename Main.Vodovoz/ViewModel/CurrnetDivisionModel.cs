using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkDivision;
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
    public class CurrnetDivisionModel : ViewModelBase
    {
        Action _changeDevision;

        private DivisionPresenter _selectedPresenterDivision;
        public DivisionPresenter SelectedPresenterDivision
        {
            get => _selectedPresenterDivision;
            set
            {
                _selectedPresenterDivision = value;
                OnPropeertyChanged();
            }
        }

        public CurrnetDivisionModel(Action changeDevision, DivisionPresenter selectedDevision)
        {
            _changeDevision = changeDevision;
            SelectedPresenterDivision = selectedDevision;

            RefreshChangeSelectedDivision = new LambdaCommand(OnRefreshChangeSelectedDivision, CanRefreshChangeSelectedDivision); //
        }

        public ICommand RefreshChangeSelectedDivision { get; }
        private bool CanRefreshChangeSelectedDivision(object p) => true;
        private async void OnRefreshChangeSelectedDivision(object p)
        {
            ChangeDevision changeDevision = new();

            string resultChange = await changeDevision.ChangeDevisionAsync(SelectedPresenterDivision);

            MessageBox.Show(resultChange);

            _changeDevision.Invoke();
        }
    }
}
