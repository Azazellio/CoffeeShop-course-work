using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Impl
{
    public class RecipeIngredientRepository:ParentRepository<CoffeeShopAppContext, RecipeIngredientDAO>
    {
        public RecipeIngredientRepository(CoffeeShopAppContext context) : base(context) { }

        public List<RecipeIngredientDAO> GetFull(List<int> Ids)
        {
            List<RecipeIngredientDAO> result = new List<RecipeIngredientDAO>();
            List<RecipeIngredientDAO> allMachineDAOs = this.GetAll().ToList();
            foreach (int machineId in Ids)
            {
                result.AddRange(this.GetWhereId(machineId));
            }
            return result;
        }

        public int GetCount()
        {
            List<RecipeIngredientDAO> allMachineIngDAOs = this.GetAll().ToList();
            return allMachineIngDAOs.Count;
        }

        public List<RecipeIngredientDAO> GetWhereId(int recipeId)
        {
            IQueryable<RecipeIngredientDAO> data = (from recing in context.RecipeIngredientDAOs
                                                     join
              rec in context.RecipeDAOs on recing.RecipeDAOId equals rec.Id
                                                     join ing in context.IngredientDAOs on recing.IngredientDAOId equals ing.Id
                                                     where recing.RecipeDAOId == recipeId
                                                     select recing)
                                              .Include(p => p.IngredientDAO)
                                              .Include(p => p.RecipeDAO);
            return data.ToList();

        }
    }
}
