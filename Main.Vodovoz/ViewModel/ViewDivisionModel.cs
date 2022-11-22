using Main.Vodovoz.Commands;
using Main.Vodovoz.Model.WorkDivision;
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
    public class ViewDivisionModel : ViewModelBase
    {
        DelDivision _delDivision;

        private List<DivisionPresenter> _collectionsDevisionPresenter;
        public List<DivisionPresenter> CollectionsDevisionPresenter
        {
            get => _collectionsDevisionPresenter;
            set
            {
                _collectionsDevisionPresenter = value;
                OnPropeertyChanged();
            }
        }

        private DivisionPresenter _selectedPresenterDivision;
        public  DivisionPresenter SelectedPresenterDivision
        {
            get => _selectedPresenterDivision;
            set
            {
                _selectedPresenterDivision = value;
                OnPropeertyChanged();
            }
        }

        public ViewDivisionModel()
        {
            StartResources();

            OPenAddDivisionsCommand = new LambdaCommand(OnOPenAddDivisionsCommand, CanOPenAddDivisionsCommand);
            OPenCurrentDivisionsCommand = new LambdaCommand(OnOPenCurrentDivisionsCommand, CanOPenCurrentDivisionsCommand);
            DeleteDivisionCommand = new LambdaCommand(OnDeleteDivisionCommand, CanDeleteDivisionCommand); //
        }

        public ICommand OPenAddDivisionsCommand { get; }
        private bool CanOPenAddDivisionsCommand(object p) => true;
        private void OnOPenAddDivisionsCommand(object p)
        {
            AddDivisionWindow viewAddDisions = new(ActionAddNewDivision);
            viewAddDisions.Show();
        }
        public ICommand OPenCurrentDivisionsCommand { get; }
        private bool CanOPenCurrentDivisionsCommand(object p)
        {
            if (SelectedPresenterDivision is null)
                return false;
            else return true;
        }
        private void OnOPenCurrentDivisionsCommand(object p)
        {
            CurrentDivisionWindow viewCurrentDisions = new(ActionChangeDivision, SelectedPresenterDivision);
            viewCurrentDisions.ShowDialog();
        }


        public ICommand DeleteDivisionCommand { get; }
        private bool CanDeleteDivisionCommand(object p)
        {
            if (SelectedPresenterDivision is null)
                return false;
            else return true;
        }
        private async void OnDeleteDivisionCommand(object p)
        {
            _delDivision = new();

            if (MessageBox.Show("Вы действительно хотите удалить подразделение?",
          "Удаление!",
          MessageBoxButton.YesNo,
          MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string resultDelDevision = await _delDivision.DeleteDevisionAsync(SelectedPresenterDivision.NameDevision);

                MessageBox.Show(resultDelDevision);

                if (resultDelDevision.Equals("Подразделение успешно удалено"))
                {
                    CollectionsDevisionPresenter.Remove(SelectedPresenterDivision);
                    RefreshCollections();
                }
            }
        }

        void StartResources()
        {
            _ = LoadDivisionPresentersAsync();
        }

        void RefreshCollections()
        {
            CollectionsDevisionPresenter = new(CollectionsDevisionPresenter);
        }

        void ActionAddNewDivision()
        {
            _ = LoadDivisionPresentersAsync();
            RefreshCollections();
        }

        async Task LoadDivisionPresentersAsync()
        {
            await Task.Run(async () =>
            {
                RecDevision recDevision = new();

                CollectionsDevisionPresenter = await recDevision.ReceiveDivisionsPresenterAsync(0);
            });
        }

        void ActionChangeDivision()
        {
            RefreshCollections();
        }
    }
}
