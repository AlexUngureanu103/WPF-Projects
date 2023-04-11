using System;
using System.Collections.Generic;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
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
                TDLNames.Add(tdlName);
                canExecute = ToDoListValidator.CanExecuteAddCategory(
                    categoryName: tdlName,
                    tdlNames: TDLNames,
                    categoryDescription: tdlDescription,
                    categoryImageSource: tdlImageSource
                    );
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

        private List<string> TDLNames;

        private AddToDoListCommands addTDLCommands;

        private StartUpPageVM startUpPageVM;

        private List<string> tdkImageSources;
        public List<string> TDLImageSources
        {
            get { return tdkImageSources; }
        }

        private string tdlName;
        public string TDLName
        {
            get { return tdlName; }
            set
            {
                tdlName = value;
                canExecute = ToDoListValidator.CanExecuteAddCategory(
                    categoryName: tdlName,
                    tdlNames: TDLNames,
                    categoryDescription: tdlDescription,
                    categoryImageSource: tdlImageSource
                    );
            }
        }

        private string tdlImageSource;
        public string TDLImageSource
        {
            get { return tdlImageSource; }
            set
            {
                tdlImageSource = "\\" + value;
                OnPropertyChanged();
                canExecute = ToDoListValidator.CanExecuteAddCategory(
                    categoryName: tdlName,
                    tdlNames: TDLNames,
                    categoryDescription: tdlDescription,
                    categoryImageSource: tdlImageSource
                    );
            }
        }

        private string tdlDescription;
        public string TDLDescription
        {
            get { return tdlDescription; }
            set
            {
                tdlDescription = value;
                canExecute = ToDoListValidator.CanExecuteAddCategory(
                    categoryName: tdlName,
                    tdlNames: TDLNames,
                    categoryDescription: tdlDescription,
                    categoryImageSource: tdlImageSource
                    );
            }
        }

        private int tdlImageIndex;
        public int TDLImageIndex
        {
            get
            {
                return tdlImageIndex;
            }
            set
            {
                tdlImageIndex = value;
                TDLImageSource = TDLImageSources[tdlImageIndex];
            }
        }

        private ICommand addTDLCommand;
        public ICommand AddTDLCommand
        {
            get
            {
                if (addTDLCommand == null)
                {
                    addTDLCommand = new RelayCommand(addTDLCommands.AddRootToDoListCommand, param => CanExecute);
                }
                return addTDLCommand;
            }
        }

        private ICommand prevImageCommand;
        public ICommand PrevImageCommand
        {
            get
            {
                if (prevImageCommand == null)
                {
                    prevImageCommand = new RelayCommand(addTDLCommands.PrevImageIndexCommand, param => true);
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
                    nextImageCommand = new RelayCommand(addTDLCommands.NextImageIndexCommand, param => true);
                }
                return nextImageCommand;
            }
        }

        public ToDoList SelectedToDoList { get; private set; }

        public AddToDoListVM(StartUpPageVM startUpPageVM, ToDoList selectedToDoList)
        {
            SelectedToDoList = selectedToDoList;
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            addTDLCommands = new AddToDoListCommands(this);
            tdkImageSources = new LoadImages(@"Images\CategoriesFolderIcons").ImagePaths;
            TDLImageIndex = 0;

            TDLNames = ExtractTasks.GetTDLNames(startUpPageVM.RootToDoList);
        }
    }
}
