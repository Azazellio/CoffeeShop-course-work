using CoffeeShop.Classes;
using CoffeeShop.Data_Handlers;
using System.Collections.Generic;

namespace CoffeeShop.Business_Logic
{
    class Presenter : IPresenter
    {
        public Net net { get; private set; }
        public Guesser guesser { get; private set; }
        public IDataAccess dataAccess { get; set; }


        public Presenter() { }
        public void SignAccess()
        {
            this.net = (Net)dataAccess.Load();
            this.guesser = new Guesser(net);
        }
        public List<string> GetGuessedList()
        {
            var list = new List<string>();
            guesser.Guess();
            foreach(Machine machine in net.machines)
            {
                list.Add(machine.Id.ToString() + " : " + guesser.GuessFor(machine).ToString());
            }
            return list;
        }
    }
}
