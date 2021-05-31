using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.BL.Impl
{
    public class GuesserService
    {
        private Guesser _guesser;
        public GuesserService(Net net)
        {
            _guesser = new Guesser(net);
        }

        public void Guess()
        {
            _guesser.Guess();
            foreach(KeyValuePair<Machine, DateTime> pair in _guesser.guessed)
            {
                pair.Key.SetGuessed(pair.Value);
            }
        }

    }
}
