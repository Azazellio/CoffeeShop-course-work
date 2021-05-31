using System;

namespace CoffeeShop.Classes
{
    class Randomizer
    {
        private Random rand;
        private Net net;
        public Randomizer(Net net)
        {
            this.net = net;
            this.rand = new Random();
        }
        public void Randomize(Machine machine, int bound)
        {
            foreach (Recipe recipe in net.mapping.Keys)
            {
                int rint = rand.Next(1, bound);
                machine.ServeNumber(recipe, rint);
            }
        }
    }
}
