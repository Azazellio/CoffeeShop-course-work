using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAO.Impl.DataContext;
using CoffeeShop.DAL.Abstract;

namespace CoffeeShop.DAL.Impl
{
    public class RecipeRepository : ParentRepository<CoffeeShopAppContext, RecipeDAO>
    {
        public RecipeRepository(CoffeeShopAppContext context) : base(context) { }
    }
}
