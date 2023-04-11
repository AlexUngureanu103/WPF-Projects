using System;
using System.Collections.Generic;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    internal class AddToDoListVM : BaseVM
    {
        private ToDoList toDoListToAdd;
        public ToDoList ToDoListToAdd
        {
            get { return toDoListToAdd; }
            set
            {
                toDoListToAdd = value;
                if (SelectedToDoList == null)
                    startUpPageVM.RootToDoList.Add(toDoListToAdd);
                else
                {
                    SelectedToDoList.toDoLists.Add(toDoListToAdd);
                }
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

        private AddToDoListCommands addCategoryCommands;

        private StartUpPageVM startUpPageVM;

        private List<string> categoryImageSources;
        public List<string> CategoryImageSources
        {
            get { return categoryImageSources; }
        }

        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                canExecute = CategoryValidator.CanExecuteAddCategory(
                    categoryName: categoryName,
                    categoryDescription: categoryDescription,
                    categoryImageSource: categoryImageSource
                    );
            }
        }

        private string categoryImageSource;
        public string CategoryImageSource
        {
            get { return categoryImageSource; }
            set
            {
                categoryImageSource = "\\" + value;
                OnPropertyChanged();
                canExecute = CategoryValidator.CanExecuteAddCategory(
                    categoryName: categoryName,
                    categoryDescription: categoryDescription,
                    categoryImageSource: categoryImageSource
                    );
            }
        }

        private string categoryDescription;
        public string CategoryDescription
        {
            get { return categoryDescription; }
            set
            {
                categoryDescription = value;
                canExecute = CategoryValidator.CanExecuteAddCategory(
                    categoryName: categoryName,
                    categoryDescription: categoryDescription,
                    categoryImageSource: categoryImageSource
                    );
            }
        }

        private int categoryImageIndex;
        public int CategoryImageIndex
        {
            get
            {
                return categoryImageIndex;
            }
            set
            {
                categoryImageIndex = value;
            }
        }

        private ICommand addCategoryCommand;
        public ICommand AddCategoryCommand
        {
            get
            {
                if (addCategoryCommand == null)
                {
                    addCategoryCommand = new RelayCommand(addCategoryCommands.AddRootToDoListCommand, param => CanExecute);
                }
                return addCategoryCommand;
            }
        }

        private ICommand prevImageCommand;
        public ICommand PrevImageCommand
        {
            get
            {
                if (prevImageCommand == null)
                {
                    prevImageCommand = new RelayCommand(addCategoryCommands.PrevImageIndexCommand, param => true);
                }
                return prevImageCommand;
            }
        }

        private ICommand nextImageCommand;
        public ICommand NextImageCommand
        {
            get
            {
                if (nextImageCommand == null)
                {
                    nextImageCommand = new RelayCommand(addCategoryCommands.NextImageIndexCommand, param => true);
                }
                return nextImageCommand;
            }
        }

        public ToDoList SelectedToDoList { get; private set; }

        public AddToDoListVM(StartUpPageVM startUpPageVM, ToDoList selectedToDoList)
        {
            SelectedToDoList = selectedToDoList;
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            addCategoryCommands = new AddToDoListCommands(this);
            categoryImageSources = new LoadImages(@"Images\CategoriesFolderIcons").ImagePaths;
            CategoryImageIndex = 0;
        }
    }
}
