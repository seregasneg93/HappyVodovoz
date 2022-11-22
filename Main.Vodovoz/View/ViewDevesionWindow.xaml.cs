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

namespace Main.Vodovoz.View
{
    /// <summary>
    /// Логика взаимодействия для ViewDevesionWindow.xaml
    /// </summary>
    public partial class ViewDevesionWindow : Window
    {
        ViewDivisionModel _vm;
        public ViewDevesionWindow()
        {
            _vm = new();
            DataContext = _vm;
            InitializeComponent();
        }
    }
}
