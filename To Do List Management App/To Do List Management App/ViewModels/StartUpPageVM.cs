﻿using System.Collections.Generic;
using To_Do_List_Management_App.ResourceManagement;
using To_Do_List_Management_App.Services;
using To_Do_List_Management_App.ToRegistribute;

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

        private List<Category> categories;
        public List<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;
            }
        }

        private StatisticsPanel thisStatisticsPanel;
        public StatisticsPanel ThisStatisticsPanel
        {
            get { return thisStatisticsPanel; }
            set
            {
                thisStatisticsPanel = value;
            }
        }

        public StartUpPageVM()
        {
            startUpPageCommands = new StartUpPageCommands(this);
            Categories = new List<Category>();
            ThisStatisticsPanel = new StatisticsPanel();
            PopulateForTest();
        }

        private void PopulateForTest()
        {
            selectedToDoList = new ToDoList()
            {
                Tasks = new List<TDTask>()
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
            categories = new List<Category>()
            {
                new Category()
                {
                    Name ="1",
                    ImageSource = "\\"+load.ImagePaths[1],
                    ToDoLists = new List<ToDoList>()
                    {
                        new ToDoList()
                        {
                            Name= "tdl1",
                            ImageSource = "\\"+load.ImagePaths[1],
                            Tasks = new List<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "fffff",
                                    Name = "Task2",
                                    priority = Enums.Priority.Urgent,
                                    type = Enums.TaskType.Event,
                                    DueDate = System.DateTime.Now,
                                    status = Enums.Status.InProgress
                                }
                            }
                        },
                        new ToDoList()
                        {
                            Name= "tdl2",
                            ImageSource = "\\"+load.ImagePaths[5],
                            Tasks = new List<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "fsaf",
                                    Name = "Trwqrwqrqwrqask2",
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
                    Name ="fsafas1",
                    ImageSource = "\\"+load.ImagePaths[8],
                    ToDoLists = new List<ToDoList>()
                    {
                        new ToDoList()
                        {
                            Name= "trwqdl1",
                            ImageSource = "\\"+load.ImagePaths[1],
                            Tasks = new List<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "fffvdssvsdff",
                                    Name = "fdsbbbbbbbbbbfsd",
                                    priority = Enums.Priority.None,
                                    type = Enums.TaskType.MajorTask,
                                    DueDate = System.DateTime.Now,
                                    status = Enums.Status.InProgress
                                }
                            }
                        },
                        new ToDoList()
                        {
                            Name= "tdfdsfl2",
                            ImageSource = "\\"+load.ImagePaths[5],
                            Tasks = new List<TDTask>()
                            {
                                new TDTask()
                                {
                                    Description = "fsfdsfdsaf",
                                    Name = "Trwqrwqrqwxxxxxrqask2",
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
