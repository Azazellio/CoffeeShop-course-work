using System;
using CoffeeShop.DAL.Impl;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections;
using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.DAL.Impl.Mappers;
using CoffeeShop.Models;
using CoffeeshopWPF.ViewModel.Impl.Infrastructure;

namespace CoffeeshopWPF.ViewModel
{
    public class MainVM
    {
        private static Net net;
        private UnitOfWork unitOfWork;
        public List<DateTime> list { get; set; }
        public Machine obj { get; set; }
        public RelayCommand AddCommand { get; set; }
        private List<MachineIngredientDAO> machinesIngrList;
        private List<RecipeIngredientDAO> recipeIngrList;

        private Net _net;
        private int _netint;
        private List<Machine> _machineModels;
        public string machineModels
        {
            get
            {
                var res = "";
                foreach(Machine machine in _machineModels)
                {
                    res += machine.Id.ToString() + " ";
                }
                return res;
            }
        }
        public string netings
        {
            get
            {
                var res = "";
                foreach(Ingredient ing in _net.ingredientsP)
                {
                    res += ing.name + " ";
                }
                res += Environment.NewLine;
                foreach(Machine machine in _net.machines)
                {
                    res += machine.Id + " ";
                }
                foreach(Recipe recipe in _net.mapping.Keys)
                {
                    foreach(KeyValuePair<Ingredient, int> ingredientPair in recipe.ingredients)
                    {
                        res += ingredientPair.Key.name + " amount :" + ingredientPair.Value;
                    }
                }
                return res;
            }
        }

        public string recing
        {
            get
            {
                string result = "";
                foreach(RecipeIngredientDAO recing in recipeIngrList)
                {
                    result += "Recipe name: " + recing.RecipeDAO.Name + " IngrName: " + recing.IngredientDAO.Name + Environment.NewLine;
                }
                return result;
            }
        }
        public int machingint
        {
            get
            {
                return this.machinesIngrList.Count;
            }
        }
        private int _machingint;

        public List<Machine> machines { get; set; }

        private Guesser guesser;

        public void Add(object message)
        {
            MessageBox.Show("");
        }


        public MainVM()
        {
            using(unitOfWork = new UnitOfWork())
            {
                var netin = new NetInitializer();
                _net = netin.InitializeNet(unitOfWork);

                var machmapper = new MachineMapper();
                _machineModels = machmapper.MapList(unitOfWork.machineRepository.GetAll().ToList(), unitOfWork);
                foreach(Machine m in _machineModels)
                    m.AddNet(_net);

                var recimapper = new RecipeMapper();
                var _recipeModels = recimapper.MapList(unitOfWork.recipeRepository.GetAll().ToList(), unitOfWork);
                foreach(KeyValuePair<Dictionary<Ingredient, int>, Drink> recipe in _recipeModels)
                    _net.AddRecipe(recipe.Value, recipe.Key);
                
                //var randomizer = new Ran

            }
            net = new Net();
            //this.guesser = new Guesser(net);
            AddCommand = new RelayCommand(Add, AddCanuse);
        }
        public bool AddCanuse(object message)
        {
            return true;
        }
    }
}
     
