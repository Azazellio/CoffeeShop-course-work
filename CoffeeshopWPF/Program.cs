using CoffeeShop.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = new Container();
            container.ProcessPresenter(new Presenter());
        }
    }
}
