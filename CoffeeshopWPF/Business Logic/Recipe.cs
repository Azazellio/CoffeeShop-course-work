using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Classes
{
    [Serializable]
    class Recipe
    {
        private Dictionary<Ingredient, int> ingredientsP;
        public IReadOnlyDictionary<Ingredient, int> ingredients {get => ingredientsP; }
        public Net net;
        public Recipe(Net net, Drink drink, Dictionary<Ingredient, int> ingred)
        {
            this.net = net;
            var ingredients = new Dictionary<Ingredient, int>();
            ingredients = ingred;
            var newingredients = CheckRecipe(ingredients);
            this.ingredientsP = newingredients;
        }
        private Dictionary<Ingredient, int> CheckRecipe(Dictionary<Ingredient, int> oldIngr)
        {
            var newingr = new Dictionary<Ingredient, int>();
            foreach(Ingredient ingr in net.ingredients)
            {
                if (!oldIngr.Keys.Contains(ingr))
                {
                    newingr.Add(ingr, 0);
                }
                else
                    newingr.Add(ingr, oldIngr[ingr]);
            }
            return newingr;
        }
        public int GetAmount(Ingredient ingredient)
        {
            return this.ingredients[ingredient];
        }
    }
}
