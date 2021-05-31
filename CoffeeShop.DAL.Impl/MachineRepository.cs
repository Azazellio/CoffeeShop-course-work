using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;

namespace CoffeeShop.DAL.Impl
{
    public class MachineRepository : ParentRepository<CoffeeShopAppContext, MachineDAO>
    {
        public MachineRepository(CoffeeShopAppContext context) : base(context) { }
    }
}
