using System;
using System.Windows.Input;

namespace To_Do_List_Management_App.Commands
{
    public class RelayCommand : ICommand
    {
        private Action commandTask;

        private Predicate<object> canExecuteTask;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        public bool CanExecute(object parameter)
        {
            return canExecuteTask != null && canExecuteTask(parameter);
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}
