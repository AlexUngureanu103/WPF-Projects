using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.Services.Commands;

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

        private ToDoList selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get { return selectedToDoList; }
            set
            {
                selectedToDoList = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPnael(categories);
                OnPropertyChanged();
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
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
                OnPropertyChanged();
            }
        }

        private StartUpPageCommands startUpPageCommands;

        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
                ThisStatisticsPanel = UpdateStatisticsPanel.UpdatedStatisticsPnael(categories);
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

        //private ICommand addTaskCommand;
        //public ICommand AddTaskCommand
        //{
        //    get
        //    {
        //        if(addTaskCommand == null)
        //        {
        //            addTaskCommand = new RelayCommand()
        //        }
        //    }
        //}

        public StartUpPageVM()
        {
            startUpPageCommands = new StartUpPageCommands(this);
            Categories = new ObservableCollection<Category>();
            ThisStatisticsPanel = new StatisticsPanel();
            PopulateForTest();
        }

        private void PopulateForTest()
        {
            selectedToDoList = new ToDoList()
            {
                Tasks = new ObservableCollection<TDTask>()
            };

            selectedToDoList.Tasks.Add(new TDTask()
            {
                Description = "aff",
                Name = "Task",
                priority = Enums.Priority.Low,
                type = Enums.TaskType.MinorTask,
                DueDate = System.DateTime.Today,
                status = Enums.Status.OnHold
            });
            selectedToDoList.Tasks.Add(new TDTask()
            {
                Description = "fffff",
                Name = "Task2",
                priority = Enums.Priority.Urgent,
                type = Enums.TaskType.Event,
                DueDate = System.DateTime.Now,
                status = Enums.Status.InProgress
            });
            LoadImages load = new LoadImages(@"Images\CategoriesFolderIcons");
            categories = new ObservableCollection<Category>()
            {
                new Category()
                {
                    Name ="Category 1",
                    ImageSource = "\\"+load.ImagePaths[1],
                    ToDoLists = new ObservableCollection<ToDoList>()
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
                new Category()
                {
                    Name ="Category2",
                    ImageSource = "\\"+load.ImagePaths[8],
                    ToDoLists = new ObservableCollection<ToDoList>()
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
