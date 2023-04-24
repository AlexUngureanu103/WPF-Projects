using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    internal class EditTaskVM : BaseVM
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

        private EditTaskCommands addTaskCommands;

        public StartUpPageVM startUpPageVM;

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
                     taskCategory: TaskCategory,
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
                     taskCategory: TaskCategory,
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
                     taskCategory: TaskCategory,
                     taskDueDate: TaskDueDate);
            }
        }

        private string taskCategory;
        public string TaskCategory
        {
            get { return taskCategory; }
            set
            {
                taskCategory = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskCategory: TaskCategory,
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
                     taskCategory: TaskCategory,
                     taskDueDate: TaskDueDate);
            }
        }

        private Status taskStatus;
        public Status TaskStatus
        {
            get { return taskStatus; }
            set
            {
                taskStatus = value;
                canExecute = TaskValidator.CanExecuteAddTask(
                     taskName: TaskName,
                     taskDescription: TaskDescription,
                     taskPriority: TaskPriority,
                     taskCategory: TaskCategory,
                     taskDueDate: TaskDueDate);
            }
        }

        private ICommand editTaskCommand;
        public ICommand EditTaskCommand
        {
            get
            {
                if (editTaskCommand == null)
                {
                    editTaskCommand = new RelayCommand(addTaskCommands.EditTask, param => CanExecute);
                }
                return editTaskCommand;
            }
        }

        private TDTask givenTDTask;
        public TDTask GivenTask
        {
            get { return givenTDTask; }
            set
            {
                givenTDTask = value;
                OnPropertyChanged();
            }
        }

        public EditTaskVM(StartUpPageVM startUpPageVM, TDTask givenTDTask)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            addTaskCommands = new EditTaskCommands(this);
            TaskDueDate = DateTime.Now.Date;
            AvailableCategories = startUpPageVM.AvailableCategories;

            if (givenTDTask == null)
            {
                TaskCategory = startUpPageVM.SelectedTDTask.Category;
                TaskDescription = startUpPageVM.SelectedTDTask.Description;
                TaskName = startUpPageVM.SelectedTDTask.Name;
                TaskDueDate = startUpPageVM.SelectedTDTask.DueDate;
                TaskPriority = startUpPageVM.SelectedTDTask.priority;
                TaskStatus = startUpPageVM.SelectedTDTask.status;
            }
            else
            {
                GivenTask = givenTDTask;
                taskCategory = givenTDTask.Category;
                TaskDescription = givenTDTask.Description;
                TaskName = givenTDTask.Name;
                TaskDueDate = givenTDTask.DueDate;
                TaskPriority = givenTDTask.priority;
                TaskStatus = givenTDTask.status;
            }
        }

        private ObservableCollection<string> availableCategories;
        public ObservableCollection<string> AvailableCategories
        {
            get { return availableCategories; }
            set
            {
                this.availableCategories = value;
                OnPropertyChanged();
            }
        }
    }
}
