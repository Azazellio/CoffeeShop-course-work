using CoffeeShop.Classes;

namespace CoffeeShop.Data_Handlers
{
    internal interface IDataAccess
    {
        object Load();
        void Save(object obj);
    }
}