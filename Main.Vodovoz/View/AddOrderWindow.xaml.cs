﻿using Main.Vodovoz.ViewModel;
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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        AddOrderModel _vm;
        public AddOrderWindow(Action addNewOrder)
        {
            _vm = new(addNewOrder);
            DataContext = _vm;
            InitializeComponent();
        }
    }
}
