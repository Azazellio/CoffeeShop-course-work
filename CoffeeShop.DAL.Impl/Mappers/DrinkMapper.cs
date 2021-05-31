using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.DAL.Impl.Mappers
{
    public class DrinkMapper
    {
        public Drink Map(DrinkDAO drinkDAO, UnitOfWork unit)
        {
            var drink = new Drink(drinkDAO.Name, drinkDAO.Id);
            return drink;
        }
        public DrinkDAO DeMap(Drink drink)
        {
            var drinkDAO = new DrinkDAO() { Name = drink.name };
            return drinkDAO;
        }
    }
}
