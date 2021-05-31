using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Models
{
    public class Recipe
    {
        public int id { get; set; }
        private Dictionary<Ingredient, int> ingredientsP;
        public IReadOnlyDictionary<Ingredient, int> ingredients {get => ingredientsP; }
        public Net net;
        public Recipe(Net net, Dictionary<Ingredient, int> ingred)
        {
            this.net = net;
            var ingredients = new Dictionary<Ingredient, int>();
            ingredientsP = ingred;
        }
        public Recipe(Dictionary<Ingredient, int> ingred)
        {
            var ingredientsP = new Dictionary<Ingredient, int>();
            ingredientsP = ingred;
        }
        public void SetNet(Net net)
        {
            this.net = net;
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
            var ing = this.ingredientsP.First(x=>x.Key.name == ingredient.name).Key;
            return this.ingredients[ing];
        }
    }
}
