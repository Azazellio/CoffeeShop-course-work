using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Classes
{
    [Serializable]
    class Ingredient
    {
        public string name { get; private set; }
        public Ingredient(string name)
        {
            this.name = name;
        }
    }
}
