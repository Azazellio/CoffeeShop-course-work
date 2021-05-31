using CoffeeshopWPF.Pages;
using CoffeeshopWPF.ViewModel;
using System.Windows;
using CoffeeshopWPF.ViewModel.Impl;

namespace CoffeeshopWPF
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
