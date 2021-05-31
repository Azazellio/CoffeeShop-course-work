using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;

namespace CoffeeShop.DAL.Impl
{
    public class IngredientRepository : ParentRepository<CoffeeShopAppContext, IngredientDAO>
    {
        public IngredientRepository(CoffeeShopAppContext context) : base(context) { }
    }
}
