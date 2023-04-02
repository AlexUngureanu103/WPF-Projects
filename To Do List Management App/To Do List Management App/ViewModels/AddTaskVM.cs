﻿using System;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Services;

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

        private AddTaskCommands addTaskCommands;

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
                if(backCommand == null)
                {
                    backCommand = new RelayCommand(addTaskCommands.BackCommand, param => CanExecute);
                }
                return backCommand;
            }
        }
        public AddTaskVM()
        {
            addTaskCommands = new AddTaskCommands(this);
        }
    }
}
