using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.DAL.Abstract
{
    public interface IUnitOfWork
    {
        void Save();
        void Dispose();
    }
}
