using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services.Commands;

namespace To_Do_List_Management_App.ViewModels
{
    internal class EditTDLVM : BaseVM
    {
        public StartUpPageVM StartUpPageVM { get; set; }

        private ObservableCollection<ToDoList> rootToDoList;
        public ObservableCollection<ToDoList> RootToDoList
        {
            get
            {
                return rootToDoList;
            }
            set
            {
                rootToDoList = value;
                OnPropertyChanged();
            }
        }

        private EditTDLCommands editTDLCommands;

        private List<string> tdkImageSources;
        public List<string> TDLImageSources
        {
            get { return tdkImageSources; }
        }

        private ToDoList selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get
            {
                return selectedToDoList;
            }
            set
            {
                selectedToDoList = value;
                OnPropertyChanged();
                TDLImageSource = selectedToDoList.ImageSource;
                tdlImageIndex = tdkImageSources.IndexOf(TDLImageSource.Remove(0, 1));
                TDLName = selectedToDoList.Name;
            }
        }


        private string tdlImageSource;
        public string TDLImageSource
        {
            get { return tdlImageSource; }
            set
            {
                if (!value.StartsWith("\\"))
                    tdlImageSource = "\\" + value;
                else
                {
                    tdlImageSource = value;
                }
                OnPropertyChanged();
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
                TDLImageSource = tdkImageSources[tdlImageIndex];
            }
        }

        private string tDLName;
        public string TDLName
        {
            get { return tDLName; }

            set
            {
                tDLName = value;
                OnPropertyChanged();
            }
        }

        private ICommand prevImageCommand;
        public ICommand PrevImageCommand
        {
            get
            {
                if (prevImageCommand == null)
                {
                    prevImageCommand = new RelayCommand(editTDLCommands.PrevImageIndexCommand, param => selectedToDoList != null);
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
                    nextImageCommand = new RelayCommand(editTDLCommands.NextImageIndexCommand, param => selectedToDoList != null);
                }
                return nextImageCommand;
            }
        }

        private ICommand saveTDL;
        public ICommand SaveTDL
        {
            get
            {
                if (saveTDL == null)
                {
                    saveTDL = new RelayCommand(editTDLCommands.SaveTDLCommand, param => selectedToDoList != null);
                }
                return saveTDL;
            }
        }

        public EditTDLVM(StartUpPageVM startUpPageVM)
        {
            StartUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            tdkImageSources = new LoadImages(@"Images\CategoriesFolderIcons").ImagePaths;
            editTDLCommands = new EditTDLCommands(this);
            tdlImageSource = "\\" + tdkImageSources[0];
            RootToDoList = startUpPageVM.RootToDoList;
        }
    }
}
