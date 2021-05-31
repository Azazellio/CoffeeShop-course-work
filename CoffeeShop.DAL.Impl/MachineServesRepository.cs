using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.DAL.Impl
{
    public class MachineServesRepository : ParentRepository<CoffeeShopAppContext, MachineServesDAO>
    {
        public MachineServesRepository(CoffeeShopAppContext context) : base(context) { }

        /*public List<MachineServesDAO> GetWhereId(int machineId)
        {
            IQueryable<MachineServesDAO> data = (from machserve in context.MachineServesDAOs
                                                     join
              mach in context.MachineDAOs on machServe.MachineDAOId equals mach.Id
                                                     join ing in context.IngredientDAOs on machIngr.IngredientDAOId equals ing.Id
                                                     where machIngr.MachineDAOId == machineId
                                                     select machIngr)
                                              .Include(p => p.IngredientDAO)
                                              .Include(p => p.MachineDAO);
            return data.ToList();

        }*/
    }
}
