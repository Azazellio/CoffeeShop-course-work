﻿using System;
using System.Windows.Input;

namespace CoffeeshopWPF.ViewModel.Impl.Infrastructure
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                var a = 0;
            }

            remove
            {
                var n = 0;
            }
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }

}

