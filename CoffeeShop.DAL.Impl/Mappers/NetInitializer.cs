using System;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.Models;

namespace CoffeeShop.DAL.Impl.Mappers
{
    public class NetInitializer
    {
        public NetInitializer() { }
        public Net InitializeNet(UnitOfWork unit)
        {
            List<IngredientDAO> ingDAOs = unit.ingredientRepository.GetAll().ToList();
            List<Ingredient> ingModels = new List<Ingredient>();
            foreach (IngredientDAO ingDAO in ingDAOs)
            {
                ingModels.Add(new Ingredient(ingDAO.Name, ingDAO.Id));
            }
            var res = new Net(ingModels);

            return res;
        }
    }
}
