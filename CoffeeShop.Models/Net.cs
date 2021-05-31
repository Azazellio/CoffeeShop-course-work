using System;
using System.Collections.Generic;
using System.Configuration;

namespace CoffeeShop.Models
{
    public class Net
    {
        public List<Machine> machinesP;
        public IReadOnlyList<Machine> machines { get => machinesP.AsReadOnly(); }
        public List<Ingredient> ingredientsP;
        public IReadOnlyList<Ingredient> ingredients { get => ingredientsP.AsReadOnly(); }

        private Dictionary<Recipe, Drink> mappingP;
        public IReadOnlyDictionary<Recipe, Drink> mapping { get => mappingP; }
        public Dictionary<Ingredient, int> EmptyDictIngred;


        public Net()
        {
            ingredientsP = new List<Ingredient>() {new Ingredient("Water"),
             new Ingredient("Coffee"), new Ingredient("Sugar"), new Ingredient("Milk")};
            machinesP = new List<Machine>();
            mappingP = new Dictionary<Recipe, Drink>();
            EmptyDictIngred = new Dictionary<Ingredient, int>()
            {
                {ingredientsP[0], 0 },
                {ingredientsP[1], 0 },
                {ingredientsP[2], 0 },
                {ingredientsP[3], 0 },
            };
        }
        public Net(List<Ingredient> ingredientsValue)
        {
            ingredientsP = new List<Ingredient>();
            foreach(Ingredient ing in ingredientsValue)
            {
                ingredientsP.Add(ing);
            }
            machinesP = new List<Machine>();
            mappingP = new Dictionary<Recipe, Drink>();
            EmptyDictIngred = new Dictionary<Ingredient, int>()
            {
                {ingredientsP[0], 0 },
                {ingredientsP[1], 0 },
                {ingredientsP[2], 0 },
                {ingredientsP[3], 0 },
            };
        }
        public void AddMachine(Machine machine)
        {
            this.machinesP.Add(machine);
        }
        private void AddMap(Recipe recipe, Drink drink)
        {
            mappingP.Add(recipe, drink);
        }
        public Recipe AddRecipe(Drink drink, Dictionary<Ingredient, int> ingred)
        {
            var newRecipe = new Recipe(this, ingred);
            AddMap(newRecipe, drink);
            return newRecipe;
        }
        public Machine Add(int waterCap, int coffeeCap, int sugarCap, int milkCap)
        {
            var machine = new Machine(waterCap, coffeeCap, sugarCap, milkCap, this);
            this.machinesP.Add(machine);
            return machine;
        }
        public List<Ingredient> GetIngredients()
        {
            return new List<Ingredient>(this.ingredientsP);
        }
        public void RefillAll()
        {
            foreach(Machine m in this.machinesP)
            {
                m.Refill();
            }
        }
    }
}
