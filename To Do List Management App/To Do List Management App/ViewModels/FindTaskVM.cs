using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;

namespace To_Do_List_Management_App.ViewModels
{
    internal class FindTaskVM : BaseVM
    {
        public readonly StartUpPageVM startUpPage;

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
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
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
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
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
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
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
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
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
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
            }
        }

        private Priority priorityToFInd;
        public Priority PriorityToFind
        {
            get { return priorityToFInd; }
            set
            {
                priorityToFInd = value;
                OnPropertyChanged();
                CanExecute = FindTaskValidator.CanExecuteFindTask(NameToFind, PriorityToFind, DueDateToFind, SearchByName, SearchByPriority, SearchByDueDate);
            }
        }

        private ICommand findCommand;
        public ICommand FindCommand
        {
            get
            {
                if (findCommand == null)
                {
                    findCommand = new RelayCommand(findTaskCommands.FindTaskCommand , param => canExecute);
                }
                return findCommand;
            }
        }

        public FindTaskVM(StartUpPageVM startUpPage)
        {
            this.startUpPage = startUpPage ?? throw new ArgumentNullException(nameof(startUpPage));
            findTaskCommands = new FindTaskCommands(this);
            categoryImageSources = new LoadImages(@"Images\SpecifiecIcons").ImagePaths;
            specifiedImageSource = categoryImageSources[0];
            DueDateToFind = DateTime.Now.Date;
        }
    }
}
