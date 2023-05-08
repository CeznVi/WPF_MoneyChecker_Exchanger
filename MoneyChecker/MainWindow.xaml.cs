using MoneyChecker.TabControls;
using MoneyChecker.Views;
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

namespace MoneyChecker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TabViewController _tabViewController;


        public MainWindow()
        {
            InitializeComponent();
            InitUI();
        }

        private void InitUI()
        {
            _tabViewController = new TabViewController();

            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.calendar, "Календарь"), new CalendarPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.bagCalc, "Бюджет"), new BudgetPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.main, "Категории"), new CategoryPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.hand, "Валюты"), new CurencyPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.handmoney, "Дебит"), new DebitPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.arcStr, "Инвойсы"), new InvoicePage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.docs, "Отчеты"), new RepotsPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.search, "Обзор"), new SearchPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.shedule, "Задачи"), new SheullerPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.transaction, "Транзакции"), new TransactionPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.people, "Пользователи"), new UsersPage()));
            _tabViewController.AddTab(new TabViewControl(TabViewControl.GetToggleButton(TabViewResource.option, "Настройки"), new RepotsPage()));

            MainWindowGrid.Children.Add(_tabViewController.Body);
            


            Grid.SetRow(_tabViewController.Body, 1);
            Grid.SetColumn(_tabViewController.Body, 0);

        }

    }
}
