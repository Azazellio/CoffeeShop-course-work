using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Drink : ICloneable
    {
        public int Id { get; set; }
        public string name { get; private set; }
        public DateTime time { get; private set; }
        public Drink(string name)
        {
            this.name = name;
        }
        public Drink(string name, int id)
        {
            this.name = name;
            this.Id = id;
        }
        public object Clone()
        {
            var newDrink = new Drink(this.name);
            newDrink.time = DateTime.Now;
            return newDrink;
        }
    }
}
