using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Models
{
    public class Ingredient
    {
        public string name { get; private set; }
        public int id { get; private set; }
        public Ingredient(string name)
        {
            this.name = name;
        }
        public Ingredient(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }
}
