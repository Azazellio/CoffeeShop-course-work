using System;
using CoffeeShop.DAL.Impl;
using System.Collections.Generic;
using System.Linq;
using CoffeeShop.DAO.Impl.DAO;
using CoffeeShop.Models;
using System.Windows.Forms;
using CoffeeshopWPF.ViewModel.Impl.Infrastructure;
using CoffeeShop.DAL.Impl.Mappers;
using CoffeeShop.BL.Impl;
using System.ComponentModel;

namespace CoffeeshopWPF.ViewModel.Impl
{
    public class MainVM:INotifyPropertyChanged
    {
        private static Net net;
        private UnitOfWork unitOfWork;
        public List<DateTime> list { get; set; }
        public Machine obj { get; set; }
        public RelayCommand UpdateCommand { get; set; }

        private Net _net;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private Machine _SelectedMachineModel;
        public Machine SelectedMachineModel
        {
            get
            {
                return _SelectedMachineModel;
            }
            set
            {
                _SelectedMachineModel = value;
                OnPropertyChanged("SelectedModelId");
                OnPropertyChanged("SelectedModelIng1");
                OnPropertyChanged("SelectedModelIng2");
                OnPropertyChanged("SelectedModelIng3");
                OnPropertyChanged("SelectedModelIng4");
                OnPropertyChanged("SelectedRefillNeeded");
            }
        }
        public string SelectedModelId
        {
            get
            {
                if (SelectedMachineModel != null)
                    return SelectedMachineModel.Id.ToString();
                else
                    return "";
            }
            set { }
        }
        public string SelectedModelIng1
        {
            get
            {
                if (SelectedMachineModel != null)
                    return SelectedMachineModel.GetCapCoffee().ToString();
                else
                    return "";
            }
            set { }
        }
        public string SelectedModelIng2
        {
            get
            {
                if (SelectedMachineModel != null)
                    return SelectedMachineModel.GetCapWater().ToString();
                else
                    return "";
            }
            set { }
        }
        public string SelectedModelIng3
        {
            get
            {
                if (SelectedMachineModel != null)
                    return SelectedMachineModel.GetCapMilk().ToString();
                else
                    return "";
            }
            set { }
        }
        public string SelectedModelIng4
        {
            get
            {
                if (SelectedMachineModel != null)
                    return SelectedMachineModel.GetCapSugar().ToString();
                else
                    return "";
            }
            set { }
        }
        public string SelectedRefillNeeded
        {
            get
            {
                if (_SelectedMachineModel != null)
                    return _SelectedMachineModel.date;
                return "";
            }
            set { }
        }
        public List<Machine> MachinesListSource
        {
            get
            {
                return _net.machinesP;
            }
        }

        public void Update(object message)
        {
            if (_SelectedMachineModel != null)
            {
                var res = _SelectedMachineModel.GetServedS();
                MessageBox.Show(res);
            }
            else
            {
                MessageBox.Show("Need to choose a model");
            }
        }

        public MainVM()
        {
            UpdateCommand = new RelayCommand(Update, UpdateCanuse);
            using (unitOfWork = new UnitOfWork())
            {
                var netin = new NetInitializer();
                _net = netin.InitializeNet(unitOfWork);

                var machmapper = new MachineMapper();
                var _machineModels = machmapper.MapList(unitOfWork.machineRepository.GetAll().ToList(), unitOfWork);
                foreach (Machine m in _machineModels)
                    m.AddNet(_net);

                var recimapper = new RecipeMapper();
                var _recipeModels = recimapper.MapList(unitOfWork.recipeRepository.GetAll().ToList(), unitOfWork);
                foreach (KeyValuePair<Dictionary<Ingredient, int>, Drink> recipe in _recipeModels)
                    _net.AddRecipe(recipe.Value, recipe.Key);
            }
            _net.RefillAll();
            var randomizer = new RandomizerService(_net);
            randomizer.Randomize(3);

            var guesser = new GuesserService(_net);
            guesser.Guess();

        }
        public bool UpdateCanuse(object message)
        {
            return true;
        }
    }
}
     
