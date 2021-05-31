using System;

namespace CoffeeShop.Models
{
    public class Randomizer
    {
        private Random rand;
        public Net net;
        public Randomizer(Net net)
        {
            this.net = net;
            this.rand = new Random();
        }
        public void Randomize(Machine machine, int bound)
        {
            foreach (Recipe recipe in net.mapping.Keys)
            {
                int rint = rand.Next(0, bound);
                machine.ServeNumber(recipe, rint);
            }
        }
    }
}
