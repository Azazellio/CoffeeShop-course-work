using System;
using System.Collections.Generic;
using System.Text;
using CoffeeShop.DAO.Impl.DataContext;
using Microsoft.EntityFrameworkCore;
using CoffeeShop.DAL.Abstract;
using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.Models;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace CoffeeShop.DAL.Impl
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private CoffeeShopAppContext context;

        private DrinkRepository _drinkRepository;
        private IngredientRepository _ingredientRepository;
        private MachineIngredientsRepository _machineIngredientsRepository;
        private MachineRepository _machineRepository;
        private MachineServesRepository _machineServesRepository;
        private RecipeRepository _recipeRepository;
        private RecipeIngredientRepository _recipeIngredientRepository;

        private bool disposed = false;

        public UnitOfWork()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CoffeeShopAppContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CoffeeShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //optionsBuilder.UseSqlServer(ConfigurationManager.AppSettings["connstr"]);
            this.context = new CoffeeShopAppContext(optionsBuilder.Options);
            this.context.Database.EnsureCreated();
        }

        public List<MachineIngredientDAO> GetMachineIngredients()
        {
            var res = new List<MachineIngredientDAO>();
            IEnumerable<MachineDAO> machs = this.machineRepository.GetAll();
            List<int> ints = new List<int>();
            foreach(MachineDAO m in machs)
            {
                ints.Add(m.Id);
            }
            res = this.machineIngredientsRepository.GetFull(ints);
            return res;
        }

        public List<RecipeIngredientDAO> GetRecipeIngredients()
        {
            var res = new List<RecipeIngredientDAO>();
            IEnumerable<RecipeDAO> machs = this.recipeRepository.GetAll();
            List<int> ints = new List<int>();
            foreach (RecipeDAO m in machs)
            {
                ints.Add(m.Id);
            }
            res = this.recipeIngredientRepository.GetFull(ints);
            return res;
        }

        public RecipeIngredientRepository recipeIngredientRepository
        {
            get
            {
                if (_recipeIngredientRepository == null)
                    _recipeIngredientRepository = new RecipeIngredientRepository(context);
                return _recipeIngredientRepository;
            }
        }

        public DrinkRepository drinkRepository
        {
            get
            {
                if (_drinkRepository == null)
                    _drinkRepository = new DrinkRepository(context);
                return _drinkRepository;
            }
        }

        public IngredientRepository ingredientRepository
        {
            get
            {
                if (_ingredientRepository == null)
                    _ingredientRepository = new IngredientRepository(context);
                return _ingredientRepository;
            }
        }

        public MachineIngredientsRepository machineIngredientsRepository
        {
            get
            {
                if (_machineIngredientsRepository == null)
                    _machineIngredientsRepository = new MachineIngredientsRepository(context);
                return _machineIngredientsRepository;
            }
        }

        public MachineRepository machineRepository
        {
            get
            {
                if (_machineRepository == null)
                    _machineRepository = new MachineRepository(context);
                return _machineRepository;
            }
        }

        public MachineServesRepository machineServesRepository
        {
            get
            {
                if (_machineServesRepository == null)
                    _machineServesRepository = new MachineServesRepository(context);
                return _machineServesRepository;
            }
        }
        public RecipeRepository recipeRepository
        {
            get
            {
                if (_recipeRepository == null)
                    _recipeRepository = new RecipeRepository(context);
                return _recipeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
