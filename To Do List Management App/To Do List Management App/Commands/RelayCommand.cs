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

        public RelayCommand(Action workToDo)
            : this(workToDo, DefaultCanExecute)
        {
            this.commandTask = workToDo ?? throw new ArgumentNullException(nameof(workToDo));
        }

        public RelayCommand(Action workToDo, Predicate<object> canExecute)
        {
            this.commandTask = workToDo ?? throw new ArgumentNullException(nameof(workToDo));
            this.canExecuteTask = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        private static bool DefaultCanExecute(object parameter)
        {
            return true;
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
