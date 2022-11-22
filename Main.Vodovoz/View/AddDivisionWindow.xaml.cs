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
using Vododvoz.Data.Data.Entyties;

namespace Main.Vodovoz.View
{
    /// <summary>
    /// Логика взаимодействия для AddDivisionWindow.xaml
    /// </summary>
    public partial class AddDivisionWindow : Window
    {
        AddDivisionModel _vm;
        public AddDivisionWindow(Action methodAdd)
        {
            _vm = new(methodAdd);
            DataContext = _vm;
            InitializeComponent();
        }
    }
}
