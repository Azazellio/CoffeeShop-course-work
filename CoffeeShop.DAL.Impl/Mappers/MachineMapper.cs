using System;
using System.Collections.Generic;
using CoffeeShop.DAL.Abstract;
using CoffeeShop.Models;
using CoffeeShop.DAO.Impl.DAO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace CoffeeShop.DAL.Impl.Mappers
{
    public class MachineMapper
    {
        public MachineMapper() { }
        public Machine Map(MachineDAO machineDAO, UnitOfWork unit)
        {
            var machineIngredientsDAO = unit.machineIngredientsRepository.GetWhereId(machineDAO.Id);

            int MaxCap1 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Coffee").MaxCapacityIngredient;
            int MaxCap2 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Water").MaxCapacityIngredient;
            int MaxCap3 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Milk").MaxCapacityIngredient;
            int MaxCap4 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Sugar").MaxCapacityIngredient;

            int CurrCap1 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Coffee").CurrentCapacityIngredient;
            int CurrCap2 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Water").CurrentCapacityIngredient;
            int CurrCap3 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Milk").CurrentCapacityIngredient;
            int CurrCap4 = machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Sugar").CurrentCapacityIngredient;

            Ingredient ingr1 = new Ingredient(machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Coffee").IngredientDAO.Name);
            Ingredient ingr2 = new Ingredient(machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Water").IngredientDAO.Name);
            Ingredient ingr3 = new Ingredient(machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Milk").IngredientDAO.Name);
            Ingredient ingr4 = new Ingredient(machineIngredientsDAO.First(x => x.IngredientDAO.Name == "Sugar").IngredientDAO.Name);


            Machine machine = new Machine()
            {
                Id = machineDAO.Id,
                MaxCapacity = new Dictionary<Ingredient, int>()
                {
                    { ingr1, MaxCap1},
                    { ingr2, MaxCap2},
                    { ingr3, MaxCap3},
                    { ingr4, MaxCap4}
                },

                CurrentCapacity = new Dictionary<Ingredient, int> ()
                {
                    { ingr1, CurrCap1},
                    { ingr2, CurrCap2},
                    { ingr3, CurrCap3},
                    { ingr4, CurrCap4}
                }
            };
            ///...Logic
            return machine;
        }
        public List<Machine> MapList(List<MachineDAO> listDAOs, UnitOfWork unit)
        {
            var res = new List<Machine>();
            foreach(MachineDAO machineDAO in listDAOs)
            {
                res.Add(Map(machineDAO, unit));
            }
            return res;
        }
    }
}
