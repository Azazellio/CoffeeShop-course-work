using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Classes
{
    [Serializable]
    class Machine
    {
        
        private static int id = 0;
        public Net net;
        private Dictionary<Ingredient, int> MaxCapacity;
        public Dictionary<Ingredient, int> CurrentCapacity;
        private List<Drink> servedDrinks;
    public int Id { get; private set; }

        public Machine(int waterCap, int coffeeCap, int sugarCap, int milkCap, Net net)
        {
            this.net = net;
            this.servedDrinks = new List<Drink>();
            this.CurrentCapacity = new Dictionary<Ingredient, int>();
            this.MaxCapacity = new Dictionary<Ingredient, int>();
            this.MaxCapacity.Add(net.GetIngredients()[0], waterCap);
            this.MaxCapacity.Add(net.GetIngredients()[1], coffeeCap);
            this.MaxCapacity.Add(net.GetIngredients()[2], sugarCap);
            this.MaxCapacity.Add(net.GetIngredients()[3], milkCap);
            this.Refill();
            this.Id = id;
            id++;
        }
        
        public void Refill()
        {
            this.CurrentCapacity = this.MaxCapacity;
        }
        private bool CanServe(Recipe recipe)
        {
            var isPossible = true;
            foreach(Ingredient ingredient in net.ingredients)
            {
                if (CurrentCapacity[ingredient] < recipe.ingredients[ingredient])
                    isPossible = false;
            }
            return isPossible;
        }
        public void Serve(Recipe recipe)
        {
            //if (this.CanServe(recipe))
            if (1 == 1)
            {
                foreach (Ingredient ingred in recipe.ingredients.Keys)
                {
                    this.CurrentCapacity[ingred] -= recipe.ingredients[ingred];
                }
                this.servedDrinks.Add((Drink)net.mapping[recipe].Clone());
            }
        }
        public void ServeNumber(Recipe recipe, int number)
        {
            for (int i = 0; i <= number; i++)
            {
                this.Serve(recipe);
            }
        }
        public string GetServedS()
        {
            var res = "";
            foreach (Drink drink in this.servedDrinks)
            {
                res += drink.name + "; ";
            }
            return res;
        }
        private Dictionary<Ingredient, int> GetAmountInServed()
        {
            var res = new Dictionary<Ingredient, int>(net.EmptyDictIngred);
            foreach(Drink drink in this.servedDrinks)
            {
                foreach (Ingredient ingredient in GetRecipeFor(drink).ingredients.Keys)
                {
                    var rec = GetRecipeFor(drink);
                    int amount = rec.GetAmount(ingredient);
                    res[ingredient] += GetRecipeFor(drink).GetAmount(ingredient);
                }
            }
            return res;
        }
        private Ingredient GetNeededIngredient(Ingredient ingredient, Dictionary<Ingredient, int> newdict)
        {
            return newdict.Keys.First(x=> x.name == ingredient.name);
        }
        private Recipe GetRecipeFor(Drink drink)
        {
            return net.mapping.First(x => x.Value.name == drink.name).Key;
        }
        public int GetShift()
        {
            var nums = GetAmountInServed();
            float shift = 1000;
            foreach (Ingredient ing in nums.Keys)
            {
                float st = (float)MaxCapacity[ing];
                float nd = (float)nums[ing];
                float newShift = st / nd;
                if (newShift < shift && newShift != 0)
                {
                    shift = newShift;
                }
            }
            return Convert.ToInt32(shift);
        }
    }
}
