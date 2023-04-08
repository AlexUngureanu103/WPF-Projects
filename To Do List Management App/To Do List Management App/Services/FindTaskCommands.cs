using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services
{
    internal class FindTaskCommands
    {
        private FindTaskVM findTaskVM;

        public FindTaskCommands(FindTaskVM findTaskVM)
        {
            this.findTaskVM = findTaskVM ?? throw new System.ArgumentNullException(nameof(findTaskVM));
        }

        public void BackCommand()
        {
            //AddCategoryVM.NavigationService.NavigateTo("MainPage");
            return;
        }

        public void FindTaskCommand()
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>();
            var allTasks = GetAllTasks(findTaskVM.startUpPage.Categories);

            if (findTaskVM.SearchByName)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = FindTasksByName(findTaskVM.NameToFind, allTasks);
                }
            }
            if (findTaskVM.SearchByDueDate)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = FindTasksByDueDate(findTaskVM.DueDateToFind, allTasks);
                }
                else
                {
                    foundedTasks = FindTasksByDueDate(findTaskVM.DueDateToFind, foundedTasks);
                }
            }
            if (findTaskVM.SearchByPriority)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = FindTasksByPriority(findTaskVM.PriorityToFind, allTasks);
                }
                else
                {
                    foundedTasks = FindTasksByPriority(findTaskVM.PriorityToFind, foundedTasks);
                }
            }

            findTaskVM.FoundedTasks = foundedTasks;
            return;
        }

        private ObservableCollection<TDTask> FindTasksByName(string taskName, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => StringMatching.IsMatch(x.Name, taskName)));
            return foundedTasks;
        }

        private ObservableCollection<TDTask> FindTasksByPriority(Priority priority, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x=>x.priority == priority));
            
            return foundedTasks;
        }

        private ObservableCollection<TDTask> FindTasksByDueDate(DateTime dueDate, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x=>DateTime.Compare(x.DueDate.Date,dueDate.Date)<=0));

            return foundedTasks;
        }

        private ObservableCollection<TDTask> GetTasks(ObservableCollection<ToDoList> toDoList)
        {
            ObservableCollection<TDTask> allTasks = new ObservableCollection<TDTask>();

            foreach (ToDoList tdList in toDoList)
            {
                foreach (TDTask tDTask in tdList.Tasks)
                {
                    allTasks.Add(tDTask);
                }
                if (tdList.toDoLists != null && tdList.toDoLists.Count > 0)
                {
                    var tasks = GetTasks(tdList.toDoLists);
                    foreach (TDTask tDTask in tasks)
                    {
                        allTasks.Add(tDTask);
                    }
                }
            }

            return allTasks;
        }

        private ObservableCollection<TDTask> GetAllTasks(ObservableCollection<Category> categories)
        {
            ObservableCollection<TDTask> allTasks = new ObservableCollection<TDTask>();

            foreach (Category category in categories)
            {
                if (category.ToDoLists != null && category.ToDoLists.Count > 0)
                {
                    var tasks = GetTasks(category.ToDoLists);
                    foreach (TDTask tDTask in tasks)
                    {
                        allTasks.Add(tDTask);
                    }
                }
            }

            return allTasks;
        }
    }
}
