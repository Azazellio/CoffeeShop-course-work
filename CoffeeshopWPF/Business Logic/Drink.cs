using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Classes
{
    [Serializable]
    class Drink : ICloneable
    {
        public string name { get; private set; }
        public DateTime time { get; private set; }
        public Drink(string name)
        {
            this.name = name;
        }
        public object Clone()
        {
            var newDrink = new Drink(this.name);
            newDrink.time = DateTime.Now;
            return newDrink;
        }
    }
}
