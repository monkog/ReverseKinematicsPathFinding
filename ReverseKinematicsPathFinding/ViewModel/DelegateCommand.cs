﻿using System;

namespace ReverseKinematicsPathFinding.ViewModel
{
    using System.Windows.Input;

    public class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute,
                       Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
	        return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter = null)
        {
            _execute(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
	        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
