﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;
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
                IsEneabledAddTDL = StartUpPageValidators.CanAddTDL(selectedToDoList);
                CanMoveUpDownTask = StartUpPageValidators.CanMoveUpDownTask(selectedToDoList, selectedTDTask);
                OnPropertyChanged();
            }
        }

        private TDTask selectedTDTask;
        public TDTask SelectedTDTask
        {
            get { return selectedTDTask; }
            set
            {
                if (value != null)
                {
                    if (value.status == Enums.Status.Completed && value.FinishDate == System.DateTime.MinValue)
                    {
                        value.FinishDate = System.DateTime.Now;
                    }
                    else if (value.status != Enums.Status.Completed)
                    {
                        value.FinishDate = System.DateTime.MinValue;
                    }
                }
                selectedTDTask = value;

                CanMoveUpDownTask = StartUpPageValidators.CanMoveUpDownTask(selectedToDoList, selectedTDTask);
                OnPropertyChanged();
                if (value != null)
                {
                    IsSelectedTDTask = true;
                }
                else
                {
                    IsSelectedTDTask = false;
                }
            }
        }

        private bool isSelectedTDTask;
        public bool IsSelectedTDTask
        {
            get { return isSelectedTDTask; }
            set
            {
                isSelectedTDTask = value;
                OnPropertyChanged();
            }
        }

        public readonly StartUpPageCommands startUpPageCommands;

        public readonly SortListViewCommands SortCommands;

        private ObservableCollection<string> availableCategories;
        public ObservableCollection<string> AvailableCategories
        {
            get { return availableCategories; }
            set
            {
                availableCategories = value;
                OnPropertyChanged();
            }
        }

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
                    deleteToDoListCommand = new RelayCommand(startUpPageCommands.DeleteToDoList, param => selectedToDoList != null);
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

        private ICommand deleteTaskCommand;
        public ICommand DeleteTaskCommand
        {
            get
            {
                if (deleteTaskCommand == null)
                {
                    deleteTaskCommand = new RelayCommand(startUpPageCommands.DeleteTask, param => isSelectedTDTask);
                }
                return deleteTaskCommand;
            }
        }

        private ICommand displayAbout;
        public ICommand DisplayAbout
        {
            get
            {
                if (displayAbout == null)
                {
                    displayAbout = new RelayCommand(startUpPageCommands.DisplayAbout, param => true);
                }
                return displayAbout;
            }
        }

        private ICommand archiveData;
        public ICommand ArchiveData
        {
            get
            {
                if (archiveData == null)
                {
                    archiveData = new RelayCommand(startUpPageCommands.ArchiveCurrentData, param => true);
                }
                return archiveData;
            }
        }

        private ICommand loadData;
        public ICommand LoadData
        {
            get
            {
                if (loadData == null)
                {
                    loadData = new RelayCommand(startUpPageCommands.LoadArchivedData, param => true);
                }
                return loadData;
            }
        }

        private ICommand sortByPriorityCommand;
        public ICommand SortByPriorityCommand
        {
            get
            {
                if (sortByPriorityCommand == null)
                {
                    sortByPriorityCommand = new RelayCommand(SortCommands.SortTasksByPriorityCommand, param => true);
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
                    sortByDueDateCommand = new RelayCommand(SortCommands.SortTasksByDueDate, param => true);
                }
                return sortByDueDateCommand;
            }
        }

        private ICommand sortByFinishDate;
        public ICommand SortByFinishDate
        {
            get
            {
                if(sortByFinishDate == null)
                {
                    sortByFinishDate = new RelayCommand(SortCommands.SortTasksFinishDate, param => true);
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
                    sortByName = new RelayCommand(SortCommands.SortTasksName, param => true);
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
                    sortByDescription = new RelayCommand(SortCommands.SortTasksDescription, param => true);
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
                    sortByStatus = new RelayCommand(SortCommands.SortTasksStatus, param => true);
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
                    sortByCategory = new RelayCommand(SortCommands.SortTasksCategory, param => true);
                }
                return sortByCategory;
            }
        }

        public StartUpPageVM()
        {
            startUpPageCommands = new StartUpPageCommands(this);
            startUpPageCommands.LoadArchivedData();
            SortCommands = new SortListViewCommands(this);
            CanFindTasks = StartUpPageValidators.CanFindTasks(rootToDoList);

            //PupulateForTest();
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
                                    Category = "Chores",
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
                                            Category = "Project",
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
                                            Category = "event",
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
                                    Category = "Project",
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
                                    Category = "Major task",
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
                                    Category = "Project",
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