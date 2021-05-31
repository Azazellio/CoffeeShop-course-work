using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;
using CoffeeShop.DAL.Impl;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Impl
{
    public class MachineIngredientsRepository : ParentRepository<CoffeeShopAppContext, MachineIngredientDAO>
    {
        public MachineIngredientsRepository(CoffeeShopAppContext context) : base(context) { }

        public IEnumerable<MachineIngredientDAO> GetMachineId(int id)
        {
            return this.ListEntities(obj => obj.MachineDAOId == id);
        }

        public List<MachineIngredientDAO> GetFull(List<int> Ids)
        {
            List<MachineIngredientDAO> result = new List<MachineIngredientDAO>();
            List<MachineIngredientDAO> allMachineDAOs = this.GetAll().ToList();
            foreach(int machineId in Ids)
            {
                result.AddRange(this.GetWhereId(machineId));
            }
            return result;
        }

        public int GetCount()
        {
            List<MachineIngredientDAO> allMachineIngDAOs = this.GetAll().ToList();
            return allMachineIngDAOs.Count;
        }

        public List<MachineIngredientDAO> GetWhereId(int machineId)
        {
            IQueryable<MachineIngredientDAO> data = (from machIngr in context.MachineIngredientDAOs
                                              join
       mach in context.MachineDAOs on machIngr.MachineDAOId equals mach.Id
                                              join ing in context.IngredientDAOs on machIngr.IngredientDAOId equals ing.Id
                                              where machIngr.MachineDAOId == machineId
                                              select machIngr)
                                              .Include(p => p.IngredientDAO)
                                              .Include(p => p.MachineDAO);
            return data.ToList();

        }
    }
}
