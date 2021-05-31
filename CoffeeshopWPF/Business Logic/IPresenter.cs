using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Business_Logic
{
    public interface IPresenter
    {
        List<string> GetGuessedList();
    }
}
