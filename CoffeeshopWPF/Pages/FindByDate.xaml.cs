using CoffeeshopWPF.ViewModel;
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
using CoffeeshopWPF.ViewModel.Impl;

namespace CoffeeshopWPF.Pages
{
    /// <summary>
    /// Interaction logic for FindByDate.xaml
    /// </summary>
    public partial class FindByDate : Page
    {
        public FindByDate(MainVM context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
