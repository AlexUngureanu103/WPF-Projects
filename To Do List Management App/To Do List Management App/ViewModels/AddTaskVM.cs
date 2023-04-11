using System;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    internal class AddTaskVM : BaseVM
    {
        private TDTask taskToAdd;
        public TDTask TaskToAdd
        {
            get { return taskToAdd; }
            set
            {
                taskToAdd = value;
                startUpPageVM.SelectedToDoList.Tasks.Add(taskToAdd);
                startUpPageVM.ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(startUpPageVM.RootToDoList);
                OnPropertyChanged();
            }
        }

        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
            }
        }

        private AddTaskCommands addTaskCommands;

        private StartUpPageVM startUpPageVM;

        private string taskName;
        public string TaskName
        {
            get { return taskName; }
            set
            {
                taskName = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskType: TaskType,
                     taskDueDate: TaskDueDate);
            }
        }

        private string taskDescription;
        public string TaskDescription
        {
            get { return taskDescription; }
            set
            {
                taskDescription = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskType: TaskType,
                     taskDueDate: TaskDueDate);
            }
        }

        private Priority taskPriority;
        public Priority TaskPriority
        {
            get { return taskPriority; }
            set
            {
                taskPriority = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskType: TaskType,
                     taskDueDate: TaskDueDate);
            }
        }

        private TaskType taskType;
        public TaskType TaskType
        {
            get { return taskType; }
            set
            {
                taskType = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskType: TaskType,
                     taskDueDate: TaskDueDate);
            }
        }

        private DateTime taskDueDate;
        public DateTime TaskDueDate
        {
            get { return taskDueDate; }
            set
            {
                taskDueDate = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskType: TaskType,
                     taskDueDate: TaskDueDate);
            }
        }

        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new RelayCommand(addTaskCommands.BackCommand, param => CanExecute);
                }
                return backCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(addTaskCommands.AddTaskCommand, param => CanExecute);
                }
                return addCommand;
            }
        }

        public AddTaskVM(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            addTaskCommands = new AddTaskCommands(this);
            TaskDueDate = DateTime.Now.Date;
        }
    }
}
