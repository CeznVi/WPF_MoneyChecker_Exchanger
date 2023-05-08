﻿using MoneyChecker.Commands.CurencyConverter;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyChecker.Views
{
    /// <summary>
    /// Логика взаимодействия для CurencyPage.xaml
    /// </summary>
    public partial class CurencyPage : Page
    {
        private CurencyConverter _curencyConverter;

        public CurencyPage()
        {
            InitializeComponent();

            _curencyConverter = new CurencyConverter();

            _curencyConverter.UpdCurrenciesToCurrentDate();
            var cur = _curencyConverter.Currencies;
        }
    }
}
