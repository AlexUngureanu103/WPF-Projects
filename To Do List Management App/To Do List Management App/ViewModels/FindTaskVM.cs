using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    internal class FindTaskVM : BaseVM
    {
        public StartUpPageVM startUpPage;

        private ObservableCollection<string> availablePriorities;
        public ObservableCollection<string> AvailableCategories
        {
            get { return availablePriorities; }
            set
            {
                availablePriorities = value;
                OnPropertyChanged();
            }
        }

        private FindTaskCommands findTaskCommands;

        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
            }
        }

        private List<string> categoryImageSources;
        public List<string> CategoryImageSources
        {
            get { return categoryImageSources; }
        }

        private string specifiedImageSource;
        public string SpecifiedImageSource
        {
            get { return specifiedImageSource; }
            set
            {
                specifiedImageSource = "\\" + value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TDTask> foundedTasks;
        public ObservableCollection<TDTask> FoundedTasks
        {
            get { return foundedTasks; }
            set
            {
                foundedTasks = value;
                OnPropertyChanged();
            }
        }

        private TDTask selectedTDTast;
        public TDTask SelectedTDTast
        {
            get { return selectedTDTast; }
            set
            {
                selectedTDTast = value;
                OnPropertyChanged();
            }
        }

        private bool searchByName;
        public bool SearchByName
        {
            get { return searchByName; }
            set
            {
                searchByName = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool displayAllTasks;
        public bool DisplayAll
        {
            get { return displayAllTasks; }
            set
            {
                displayAllTasks = value;
                if (value == true)
                {
                    SearchByName = false;
                    SearchByDueDate = false;
                    SearchByPriority = false;
                    SearchByTaskStatus = false;
                    SearchByTaskCategory = false;
                    SearchCompletedTasks = false;
                    SearchUncompletedTasks = false;
                    SearchOverDueTasks = false;
                    SearchNotOverDueTasks = false;
                    CanExecute = true;
                }
                OnPropertyChanged();
            }
        }

        private bool searchByDueDate;
        public bool SearchByDueDate
        {
            get { return searchByDueDate; }
            set
            {
                searchByDueDate = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchByPriority;
        public bool SearchByPriority
        {
            get { return searchByPriority; }
            set
            {
                searchByPriority = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchByTaskCategory;
        public bool SearchByTaskCategory
        {
            get { return searchByTaskCategory; }
            set
            {
                searchByTaskCategory = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchByTaskStatus;
        public bool SearchByTaskStatus
        {
            get { return searchByTaskStatus; }
            set
            {
                searchByTaskStatus = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchCompletedTasks;
        public bool SearchCompletedTasks
        {
            get { return searchCompletedTasks; }
            set
            {
                searchCompletedTasks = value;
                if (value == true)
                    SearchUncompletedTasks = false;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchUncompletedTasks;
        public bool SearchUncompletedTasks
        {
            get { return searchUncompletedTasks; }
            set
            {
                searchUncompletedTasks = value;
                if (value == true)
                    SearchCompletedTasks = false;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchOverDueTasks;
        public bool SearchOverDueTasks
        {
            get { return searchOverDueTasks; }
            set
            {
                searchOverDueTasks = value;
                if (value == true)
                    SearchNotOverDueTasks = false;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private bool searchNotOverDueTasks;
        public bool SearchNotOverDueTasks
        {
            get { return searchNotOverDueTasks; }
            set
            {
                searchNotOverDueTasks = value;
                if (value == true)
                    SearchOverDueTasks = false;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private string nameToFind;
        public string NameToFind
        {
            get { return nameToFind; }
            set
            {
                nameToFind = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private DateTime dueDateToFind;
        public DateTime DueDateToFind
        {
            get { return dueDateToFind; }
            set
            {
                dueDateToFind = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private string taskCategoryToFind;
        public string TaskCategoryToFind
        {
            get { return taskCategoryToFind; }
            set
            {
                taskCategoryToFind = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private Status taskStatusToFind;
        public Status TaskStatusToFind
        {
            get { return taskStatusToFind; }
            set
            {
                taskStatusToFind = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private Priority priorityToFind;
        public Priority PriorityToFind
        {
            get { return priorityToFind; }
            set
            {
                priorityToFind = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(
                    taskName: nameToFind, searchByName: searchByName,
                    taskPriority: priorityToFind, searchByPriority: searchByPriority,
                    taskDueDate: dueDateToFind, searchByDueDate: searchByDueDate,
                    status: taskStatusToFind, searchByStatus: searchByTaskStatus,
                    taskCategory: taskCategoryToFind, searchByType: searchByTaskCategory,
                    searchByCompleted: searchCompletedTasks, searchByUnCompleted: searchUncompletedTasks,
                    searchByOverDue: searchOverDueTasks, searchByNotOverDue: searchNotOverDueTasks);
            }
        }

        private ICommand findCommand;
        public ICommand FindCommand
        {
            get
            {
                if (findCommand == null)
                {
                    findCommand = new RelayCommand(findTaskCommands.FindTaskCommand, param => canExecute);
                }
                return findCommand;
            }
        }

        private ICommand sortByPriorityCommand;
        public ICommand SortByPriorityCommand
        {
            get
            {
                if (sortByPriorityCommand == null)
                {
                    sortByPriorityCommand = new RelayCommand(findTaskCommands.SortTasksByPriorityCommand, param => true);
                }
                return sortByPriorityCommand;
            }
        }

        private ICommand sortByDueDateCommand;
        public ICommand SortByDueDateCommand
        {
            get
            {
                if (sortByDueDateCommand == null)
                {
                    sortByDueDateCommand = new RelayCommand(findTaskCommands.SortTasksByDueDate, param => true);
                }
                return sortByDueDateCommand;
            }
        }

        private ICommand sortByFinishDate;
        public ICommand SortByFinishDate
        {
            get
            {
                if (sortByFinishDate == null)
                {
                    sortByFinishDate = new RelayCommand(findTaskCommands.SortTasksFinishDate, param => true);
                }
                return sortByFinishDate;
            }
        }

        private ICommand sortByName;
        public ICommand SortByName
        {
            get
            {
                if (sortByName == null)
                {
                    sortByName = new RelayCommand(findTaskCommands.SortTasksName, param => true);
                }
                return sortByName;
            }
        }

        private ICommand sortByDescription;
        public ICommand SortByDescription
        {
            get
            {
                if (sortByDescription == null)
                {
                    sortByDescription = new RelayCommand(findTaskCommands.SortTasksDescription, param => true);
                }
                return sortByDescription;
            }
        }

        private ICommand sortByStatus;
        public ICommand SortByStatus
        {
            get
            {
                if (sortByStatus == null)
                {
                    sortByStatus = new RelayCommand(findTaskCommands.SortTasksStatus, param => true);
                }
                return sortByStatus;
            }
        }

        private ICommand sortByCategory;
        public ICommand SortByCategory
        {
            get
            {
                if (sortByCategory == null)
                {
                    sortByCategory = new RelayCommand(findTaskCommands.SortTasksCategory, param => true);
                }
                return sortByCategory;
            }
        }

        public FindTaskVM(StartUpPageVM startUpPage)
        {
            this.startUpPage = startUpPage ?? throw new ArgumentNullException(nameof(startUpPage));
            findTaskCommands = new FindTaskCommands(this);
            categoryImageSources = new LoadImages(@"Images\SpecifiecIcons").ImagePaths;
            specifiedImageSource = categoryImageSources[0];
            DueDateToFind = DateTime.Now.Date;
            AvailableCategories = startUpPage.AvailableCategories;
        }
    }
}
