using MoneyChecker.Commands.CurencyConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            InitialInterface();

        }

        private void InitialInterface()
        {
            
            ComboBox_HaveValut.ItemsSource = new List<string>() { "Гривні" }; 
            ComboBox_WantByeValut.ItemsSource = _curencyConverter.GetCurrenciesName();
   
        }

        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBox_HaveValut.SelectedItem != null && ComboBox_WantByeValut.SelectedItem != null)
                if (ComboBox_HaveValut.SelectedItem.ToString() != string.Empty
                    && ComboBox_WantByeValut.SelectedItem.ToString() != string.Empty
                    && TextBox_HaveValut.Text != string.Empty)
                {
                    if (CheckBox_UseDate.IsChecked == true)
                    {
                        if(Calendar.SelectedDate <= DateTime.Now)
                            _curencyConverter.UpdCurrenciesByDate(Calendar.SelectedDate.Value);
                    }
                    else
                    {
                        _curencyConverter.UpdCurrenciesToCurrentDate();
                    }

                    TextBox_WantByeValut.Text =
                        _curencyConverter.CalculateWithoutDate(
                            double.Parse(TextBox_HaveValut.Text),
                            ComboBox_HaveValut.SelectedItem.ToString(),
                            ComboBox_WantByeValut.SelectedItem.ToString()).ToString();


                }    
                    

        }

        private void TextBox_HaveValut_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (!Char.IsDigit(e.Text, 0) && (e.Text != ",")) 
                e.Handled = true;
            else
                if ((e.Text == ",") && ((tb.Text.IndexOf(",") != -1) || (tb.Text == "")))
                { 
                    e.Handled = true; 
                }
        }

        private void Button_ChangeValute_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBox_HaveValut.SelectedItem != null && ComboBox_WantByeValut.SelectedItem != null)
                if (ComboBox_HaveValut.SelectedItem.ToString() != string.Empty
                    && ComboBox_WantByeValut.SelectedItem.ToString() != string.Empty)
                {

                    string temp1 = ComboBox_WantByeValut.SelectedItem.ToString();
                    var source1 = ComboBox_WantByeValut.ItemsSource;
                    ComboBox_WantByeValut.SelectedItem = null;
                    ComboBox_WantByeValut.ItemsSource = null;


                    string temp2 = ComboBox_HaveValut.SelectedItem.ToString();
                    var source2 = ComboBox_HaveValut.ItemsSource;
                    ComboBox_HaveValut.SelectedItem = null;
                    ComboBox_HaveValut.ItemsSource = null;


                    ComboBox_WantByeValut.ItemsSource = source2;
                    ComboBox_WantByeValut.SelectedItem = temp2;

                    ComboBox_HaveValut.ItemsSource = source1;
                    ComboBox_HaveValut.SelectedItem = temp1;

                }
        }
    }
}
