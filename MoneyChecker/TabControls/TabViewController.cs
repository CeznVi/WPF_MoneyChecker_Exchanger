using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MoneyChecker.TabControls
{
    class TabViewController
    {
        private Grid _bodyControl;

        private List<TabViewControl> _tabs = new List<TabViewControl>();

        private ToolBar _toolBar;

        private Frame _frame;

        /* Property                  --------------------------НАЧАЛО*/
        public Grid Body
        {
            get { return _bodyControl; }
        }
        public Frame Frame
        { 
            get { return _frame; } 
        }
        /* Property                  --------------------------КОНЕЦ*/


        public void AddTab(TabViewControl tabViewControl)
        {
            _tabs.Add(tabViewControl);

            _toolBar.Items.Add(tabViewControl.Tab.Key);

            _frame.Navigate(tabViewControl.Tab.Value);

            tabViewControl.Tab.Key.Click += Key_Click;
        }

        private void Key_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton clicked = (ToggleButton)sender;

            foreach (var item in _tabs)
            {
                item.Tab.Key.IsChecked = false;

                if (item.Tab.Key == clicked)
                {
                    item.Tab.Key.IsChecked = true;
                    _frame.Navigate(item.Tab.Value);    
                }
            }
        }

        /* CTOR */
        public TabViewController()
        {
            _bodyControl = new Grid();
            RowDefinition rowsButtons = new RowDefinition();
            rowsButtons.Height = new GridLength(60, GridUnitType.Pixel);
            
            _bodyControl.RowDefinitions.Add(rowsButtons);

            _bodyControl.RowDefinitions.Add(new RowDefinition());
            _bodyControl.ColumnDefinitions.Add(new ColumnDefinition());

            _toolBar = new ToolBar();
            Grid.SetRow(_toolBar, 0);
            Grid.SetColumn(_toolBar, 0);

            _frame = new Frame();
            _frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
           
            Grid.SetRow(_frame, 1);
            Grid.SetColumn(_frame, 0);

            _bodyControl.Children.Add(_toolBar);
            _bodyControl.Children.Add(_frame);
        }
    }
}
