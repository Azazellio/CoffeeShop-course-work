using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CoffeeshopWPF.Pages;
using CoffeeshopWPF.ViewModel.Impl;

namespace CoffeeShopWPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static FindByDate fbdPage;
        static FindByName fbnPage;
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainVM();
            DataContext = vm;
            fbdPage = new FindByDate(vm);
            fbnPage = new FindByName(vm);
            Container.Content = fbnPage;
        }

        private void MenuItem1Click(object sender, RoutedEventArgs e)
        {
            Container.Content = fbdPage;
        }

        private void MenuItem2Click(object sender, RoutedEventArgs e)
        {
            Container.Content = fbnPage;
        }
    }
}
