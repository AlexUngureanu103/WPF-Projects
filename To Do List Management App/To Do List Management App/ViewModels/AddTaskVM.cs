using System.Windows.Input;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.ToRegistribute;

namespace To_Do_List_Management_App.ViewModels
{
    internal class AddTaskVM : BaseVM
    {
        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
            }
        }
        
        private TDTask task;
        public TDTask Task
        {
            get { return task; }
            set
            {
                task = value;
                canExecute = TaskValidator.CanExecuteAddTask(task);
            }
        }

        public AddTaskVM()
        {
        }
    }
}
