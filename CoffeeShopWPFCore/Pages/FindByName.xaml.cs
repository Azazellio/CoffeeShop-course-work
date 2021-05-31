using CoffeeshopWPF.ViewModel;
using CoffeeshopWPF.ViewModel.Impl;
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

namespace CoffeeshopWPF.Pages
{
    /// <summary>
    /// Interaction logic for FindByName.xaml
    /// </summary>
    public partial class FindByName : Page
    {
        public FindByName(MainVM context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
