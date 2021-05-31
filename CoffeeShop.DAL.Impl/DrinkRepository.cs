using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;

namespace CoffeeShop.DAL.Impl
{
    public class DrinkRepository : ParentRepository<CoffeeShopAppContext, DrinkDAO>
    {
        public DrinkRepository(CoffeeShopAppContext context) : base(context) { }
    }
}
