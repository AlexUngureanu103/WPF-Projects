﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;
using To_Do_List_Management_App.Services.SerializeData;
using To_Do_List_Management_App.Services.Validators;

namespace To_Do_List_Management_App.ViewModels
{
    public class StartUpPageVM : BaseVM
    {
        private bool canExecute;
        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                canExecute = value;
                SaveApplication();
            }
        }

        private bool isEneabledAddTDL;
        public bool IsEneabledAddTDL
        {
            get { return isEneabledAddTDL; }
            set
            {
                isEneabledAddTDL = value;
                OnPropertyChanged();
            }
        }

        private bool canFindTasks;
        public bool CanFindTasks
        {
            get { return canFindTasks; }
            set
            {
                canFindTasks = value;
                OnPropertyChanged();
            }
        }

        private bool canMoveUpDownTask;
        public bool CanMoveUpDownTask
        {
            get { return canMoveUpDownTask; }
            set
            {
                canMoveUpDownTask = value;
                OnPropertyChanged();
            }
        }

        private ToDoList selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get
            {
                CanFindTasks = StartUpPageValidators.CanFindTasks(rootToDoList);
                return selectedToDoList;
            }
            set
            {
                selectedToDoList = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(rootToDoList);
                SaveApplication();
                IsEneabledAddTDL = StartUpPageValidators.CanAddTDL(selectedToDoList);
                CanMoveUpDownTask = StartUpPageValidators.CanMoveUpDownTask(selectedToDoList, selectedTDTask);
                OnPropertyChanged();
            }
        }

        private TDTask selectedTDTask;
        public TDTask SelectedTDTast
        {
            get { return selectedTDTask; }
            set
            {
                selectedTDTask = value;
                SaveApplication();
                CanMoveUpDownTask = StartUpPageValidators.CanMoveUpDownTask(selectedToDoList, selectedTDTask);
                OnPropertyChanged();
            }
        }

        private StartUpPageCommands startUpPageCommands;

        private ManageDataUsage ManageData;

        private ObservableCollection<ToDoList> rootToDoList;
        public ObservableCollection<ToDoList> RootToDoList
        {
            get
            {
                CanFindTasks = StartUpPageValidators.CanFindTasks(rootToDoList);
                return rootToDoList;
            }
            set
            {
                rootToDoList = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPanel(rootToDoList);
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private StatisticsPanel thisStatisticsPanel;
        public StatisticsPanel ThisStatisticsPanel
        {
            get { return thisStatisticsPanel; }
            set
            {
                thisStatisticsPanel = value;
                SaveApplication();
                OnPropertyChanged();
            }
        }

        private ICommand deleteToDoListCommand;
        public ICommand DeleteToDoListCommand
        {
            get
            {
                if (deleteToDoListCommand == null)
                {
                    deleteToDoListCommand = new RelayCommand(startUpPageCommands.DeleteToDoList, param => selectedTDTask != null);
                }
                return deleteToDoListCommand;
            }
        }

        private ICommand moveUpTaskCommand;
        public ICommand MoveUpTaskCommand
        {
            get
            {
                if (moveUpTaskCommand == null)
                {
                    moveUpTaskCommand = new RelayCommand(startUpPageCommands.MoveTaskUp, param => canMoveUpDownTask);
                }
                return moveUpTaskCommand;
            }
        }

        private ICommand moveDownTaskCommand;
        public ICommand MoveDownTaskCommand
        {
            get
            {
                if (moveDownTaskCommand == null)
                {
                    moveDownTaskCommand = new RelayCommand(startUpPageCommands.MoveTaskDown, param => canMoveUpDownTask);
                }
                return moveDownTaskCommand;
            }
        }

        public StartUpPageVM()
        {
            ManageData = new ManageDataUsage("Save");
            ReloadApplication();
            startUpPageCommands = new StartUpPageCommands(this);
            CanFindTasks = StartUpPageValidators.CanFindTasks(rootToDoList);
            //PupulateForTest();
        }

        private void ReloadApplication()
        {
            var structure = ManageData.LoadData();

            selectedToDoList = structure.SelectedToDoList;
            selectedTDTask = structure.SelectedTDTask;
            rootToDoList = structure.Categories;
            thisStatisticsPanel = structure.StatisticsPanel;
        }

        private void SaveApplication()
        {
            CurrentStructure currentStructure = new CurrentStructure()
            {
                Categories = this.rootToDoList,
                SelectedTDTask = this.selectedTDTask,
                SelectedToDoList = this.selectedToDoList,
                StatisticsPanel = this.thisStatisticsPanel
            };
            ManageData.SaveData(currentStructure);
        }

        private void PupulateForTest()
        {
            LoadImages load = new LoadImages(@"Images\CategoriesFolderIcons");
            rootToDoList = new ObservableCollection<ToDoList>()
            {
                new ToDoList()
                {
                    Name ="Category 1",
                    ImageSource = "\\"+load.ImagePaths[1],
                    toDoLists = new ObservableCollection<ToDoList>()
                    {
                        new ToDoList()
                        {
                            Name= "C1  TD1",
                            ImageSource = "\\"+load.ImagePaths[1],
                            Tasks = new ObservableCollection<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "Dishes",
                                    Name = "task C1 TD1 T1",
                                    priority = Enums.Priority.Urgent,
                                    type = Enums.TaskType.Chores,
                                    DueDate = System.DateTime.Now.AddDays(-2),
                                    status = Enums.Status.InProgress
                                }
                            },
                            toDoLists = new ObservableCollection<ToDoList>(){
                                new ToDoList()
                                {
                                    Name = "C1 TD1 TD1",
                                    ImageSource = "\\"+load.ImagePaths[1],
                                    Tasks = new ObservableCollection<TDTask>()
                                    {
                                        new TDTask()
                                        {
                                            Description = "MVP",
                                            Name = "task C1 TD1 TD1 T1",
                                            priority = Enums.Priority.High,
                                            type = Enums.TaskType.Project,
                                            DueDate = System.DateTime.Now.AddDays(-2),
                                            status = Enums.Status.InProgress
                                        }
                                    }
                                },
                                new ToDoList()
                                {
                                    Name = "C1 TD1 TD2",
                                    ImageSource = "\\"+load.ImagePaths[1],
                                    Tasks = new ObservableCollection<TDTask>()
                                    {
                                        new TDTask()
                                        {
                                            Description = "BRTA",
                                            Name = "task C1 TD1 TD2 T1",
                                            priority = Enums.Priority.Urgent,
                                            type = Enums.TaskType.Event,
                                            DueDate = System.DateTime.Now.AddDays(-2),
                                            status = Enums.Status.InProgress
                                        }
                                    }
                                }
                            }
                        },
                        new ToDoList()
                        {
                            Name= "C1  TD2",
                            ImageSource = "\\"+load.ImagePaths[5],
                            Tasks = new ObservableCollection<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "RC",
                                    Name = "task C1 TD2 T1",
                                    priority = Enums.Priority.Low,
                                    type = Enums.TaskType.Project,
                                    DueDate = System.DateTime.Now,
                                    status = Enums.Status.InProgress
                                }
                            }
                        },
                    }
                },
                new ToDoList()
                {
                    Name ="Category2",
                    ImageSource = "\\"+load.ImagePaths[8],
                    toDoLists = new ObservableCollection<ToDoList>()
                    {
                        new ToDoList()
                        {
                            Name= "C2  TD1",
                            ImageSource = "\\"+load.ImagePaths[1],
                            Tasks = new ObservableCollection<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "None",
                                    Name = "task C2 TD1 T1",
                                    priority = Enums.Priority.None,
                                    type = Enums.TaskType.MajorTask,
                                    DueDate = System.DateTime.Now,
                                    status = Enums.Status.InProgress
                                }
                            }
                        },
                        new ToDoList()
                        {
                            Name= "C2 TD2",
                            ImageSource = "\\"+load.ImagePaths[5],
                            Tasks = new ObservableCollection<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "Trivia",
                                    Name = "task C2 TD2 T1",
                                    priority = Enums.Priority.Low,
                                    type = Enums.TaskType.Project,
                                    DueDate = System.DateTime.Now,
                                    status = Enums.Status.InProgress
                                }
                            }
                        },
                    }
                }
            };
        }
    }
}