using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.DAL.Abstract
{
    interface IMapper <Tdao, Tmodel, Tunit> where Tunit: IUnitOfWork
    {
        Tmodel Map(Tdao dao, Tunit unit);
        Tdao DeMap(Tmodel model, Tunit tunit);
        List<Tmodel> MapList(IEnumerable<Tdao> daoList, Tunit unit);
    }
}
