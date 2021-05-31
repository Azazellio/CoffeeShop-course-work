using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.BL.Impl
{
    public class RandomizerService
    {
        private Randomizer _randomizer;
        public RandomizerService(Net net)
        {
            _randomizer = new Randomizer(net);
        }
        public void Randomize(int bound)
        {
            foreach(Machine m in _randomizer.net.machines)
            {
                _randomizer.Randomize(m, bound);
            }
        }
    }
}
