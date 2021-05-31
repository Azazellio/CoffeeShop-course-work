using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Tracing;
using System.Runtime.InteropServices;
using System.Text;

namespace CoffeeShop.DAL.Impl.Mappers
{
    public class RecipeMapper
    {
        public RecipeMapper() { }

        public KeyValuePair<Dictionary<Ingredient, int>, Drink> Map(RecipeDAO recipeDAO, UnitOfWork unit)
        {
            List<RecipeIngredientDAO> recipeIngredientsDAO = unit.recipeIngredientRepository.GetWhereId(recipeDAO.Id);
            var tempIngAmountList = new Dictionary<Ingredient, int>();

            /*var tempIntList = new List<int>();
            foreach(RecipeIngredientDAO amount in recipeIngredientsDAO)
            {
                tempIntList.Add(amount.Amount);
            }*/

            var drinkDAO = unit.drinkRepository.Get(recipeDAO.DrinkDAOId.GetValueOrDefault());

            var drink = new Drink(drinkDAO.Name, drinkDAO.Id);
            List<RecipeIngredientDAO> filteredRecipeIngrDAOs = recipeIngredientsDAO.Where(x => x.RecipeDAOId == recipeDAO.Id).ToList();
            foreach(RecipeIngredientDAO recingDAO in filteredRecipeIngrDAOs)
            {
                Ingredient ing = new Ingredient(recingDAO.IngredientDAO.Name, recingDAO.IngredientDAO.Id);
                //var testRecipeIngr = unit.recipeIngredientRepository.GetWhereId(recipeDAO.Id).Find(x=>x.Id==recingDAO.Id);
                var amount = recingDAO.Amount;
                //int amount = tempIntList.Find(x=>x==recingDAO.Amount);
                tempIngAmountList.Add(ing, amount);
            }
            return new KeyValuePair<Dictionary<Ingredient, int>, Drink>(tempIngAmountList, drink);
        }

        public Dictionary<Dictionary<Ingredient, int>, Drink> MapList(List<RecipeDAO> recipeDAOs, UnitOfWork unitOfWork)
        {
            var res = new Dictionary<Dictionary<Ingredient, int>, Drink>();
            foreach(RecipeDAO recipeDAO in recipeDAOs)
            {
                var keypair = Map(recipeDAO, unitOfWork);
                res.Add(keypair.Key, keypair.Value);
            }
            return res;
        }
    }
}
