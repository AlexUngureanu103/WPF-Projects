using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;

namespace To_Do_List_Management_App.ViewModels
{
    internal class FindTaskVM : BaseVM
    {
        public readonly StartUpPageVM startUpPage;

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

        private bool searchByName;
        public bool SearchByName
        {
            get { return searchByName; }
            set
            {
                searchByName = value;
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
            }
        }


        public FindTaskVM(StartUpPageVM startUpPage)
        {
            this.startUpPage = startUpPage ?? throw new ArgumentNullException(nameof(startUpPage));
            categoryImageSources = new LoadImages(@"Images\SpecifiecIcons").ImagePaths;
            specifiedImageSource = categoryImageSources[0];
        }
    }
}
