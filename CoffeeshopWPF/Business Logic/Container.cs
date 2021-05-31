using CoffeeShop.Data_Handlers;
using CoffeeshopWPF;

namespace CoffeeShop.Business_Logic
{
    class Container
    {
        Presenter presenter;
        DataAccess dataAcc;
        MainWindow mW;
        public Container() { }
        public MainWindow ProcessForm(MainWindow window)
        {
            this.mW = window;
            window.presenter = presenter;
            return window;
        }
        public Presenter ProcessPresenter(Presenter presenter)
        {
            this.presenter = presenter;
            presenter.dataAccess = new DataAccess();
            presenter.SignAccess();
            return presenter;
        }
    }
}
