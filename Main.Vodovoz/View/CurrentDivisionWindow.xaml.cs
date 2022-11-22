using Main.Vodovoz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Vodovoz.Services.Presenters;

namespace Main.Vodovoz.View
{
    /// <summary>
    /// Логика взаимодействия для CurrentDivisionWindow.xaml
    /// </summary>
    public partial class CurrentDivisionWindow : Window
    {
        CurrnetDivisionModel _vm;
        public CurrentDivisionWindow(Action changeDevision, DivisionPresenter selectedDevision)
        {
            _vm = new(changeDevision, selectedDevision);
            DataContext = _vm;
            InitializeComponent();
        }
    }
}
