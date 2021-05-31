using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Models
{
    public class Machine
    {
        public Net net;
        public Dictionary<Ingredient, int> MaxCapacity;
        public Dictionary<Ingredient, int> CurrentCapacity;
        public List<Drink> servedDrinks;
        public DateTime guessedValue;
        public string MissingIngredient
        {
            get
            {
                int i = 1000;
                foreach(int amount in this.CurrentCapacity.Values)
                {
                    if (amount < i)
                        i = amount;
                }
                var pair = this.CurrentCapacity.First(x => x.Value == i);
                Ingredient ing = pair.Key;
                return ing.name;
            }
        }
        public string date
        {
            get
            {
                return this.guessedValue.ToString();
            }
        }

        public int Id { get; set; }

        public Machine()
        {
            this.servedDrinks = new List<Drink>();
        }
        public int GetCapCoffee()
        {
            int integer = this.CurrentCapacity.First(x => x.Key.name == "Coffee").Value;
            return integer;
        }
        public int GetCapWater()
        {
            int integer = this.CurrentCapacity.First(x => x.Key.name == "Water").Value;
            return integer;
        }
        public int GetCapMilk()
        {
            int integer = this.CurrentCapacity.First(x => x.Key.name == "Milk").Value;
            return integer;
        }
        public int GetCapSugar()
        {
            int integer = this.CurrentCapacity.First(x => x.Key.name == "Sugar").Value;
            return integer;
        }
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
        }

        public void SetGuessed(DateTime dt)
        {
            this.guessedValue = dt;
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
                var ingMachine = this.FindNeedenIngredientForCurrCap(ingredient);
                Ingredient ingRecipe = recipe.ingredients.First(x => x.Key.name == ingredient.name).Key;
                if (CurrentCapacity[ingMachine] < recipe.ingredients[ingRecipe])
                    isPossible = false;
            }
            return isPossible;
        }
        public void Serve(Recipe recipe)
        {
            if (this.CanServe(recipe))
            {
                foreach (Ingredient ingred in recipe.ingredients.Keys)
                {
                    var temping = this.FindNeededIngredient(ingred);
                    this.CurrentCapacity[temping] -= recipe.ingredients[ingred];
                    //this.CurrentCapacity[temping] -= 1;
                }
                this.servedDrinks.Add((Drink)net.mapping[recipe].Clone());
            }
        }
        private Ingredient FindNeededIngredient(Ingredient ingredient)
        {
            return this.CurrentCapacity.Keys.First(x=>x.name == ingredient.name);
        }
        public void ServeNumber(Recipe recipe, int number)
        {
            for (int i = 0; i < number; i++)
            {
                this.Serve(recipe);
            }
        }
        public void AddNet(Net net)
        {
            this.net = net;
            net.AddMachine(this);
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
                    //var ing = this.FindNeededIngredient(ingredient);
                    Ingredient ing = net.EmptyDictIngred.First(x => x.Key.name == ingredient.name).Key;
                    res[ing] += GetRecipeFor(drink).GetAmount(ing);
                }
            }
            return res;
        }
        public string GetIngredientsAmounts()
        {
            var res = "";
            foreach(var pair in this.CurrentCapacity)
            {
                res += pair.Key.name + " " + pair.Value.ToString() + Environment.NewLine;
            }
            return res;
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
                var temping = this.FindNeedenIngredientForMaxCap(ing);
                float st = (float)MaxCapacity[temping];
                float nd = (float)nums[ing];
                float newShift = st / nd;
                if (newShift < shift && newShift != 0)
                {
                    shift = newShift;
                }
            }
            return Convert.ToInt32(shift);
        }
        private Ingredient FindNeedenIngredientForMaxCap(Ingredient ing)
        {
            return this.MaxCapacity.Keys.First(x=>x.name == ing.name);
        }
        private Ingredient FindNeedenIngredientForCurrCap(Ingredient ing)
        {
            return this.CurrentCapacity.Keys.First(x => x.name == ing.name);
        }
    }
}
