using CoffeeShop.Data_Handlers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace CoffeeShop.Classes
{
    [Serializable]
    class Net
    {
        private List<Machine> machinesP;
        public IReadOnlyList<Machine> machines { get => machinesP.AsReadOnly(); }

        private List<Ingredient> ingredientsP;
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
        /*public Net()
        {
            var bs = new BinarySerializer();
            var newNet = (Net)bs.Deserialize(ConfigurationManager.AppSettings["binfile"]);
            this.ingredientsP = new List<Ingredient>(newNet.ingredientsP)
            this.machinesP = new List<Machine>(newNet.machinesP);
            this.mappingP = new Dictionary<Recipe, Drink>(newNet.mappingP);
            this.EmptyDictIngred = new Dictionary<Ingredient, int>(newNet.EmptyDictIngred);
        }*/
        private void AddMap(Recipe recipe, Drink drink)
        {
            mappingP.Add(recipe, drink);
        }
        public Recipe AddRecipe(Drink drink, Dictionary<Ingredient, int> ingred)
        {
            var newRecipe = new Recipe(this, drink, ingred);
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
    }
}
