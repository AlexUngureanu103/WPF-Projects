using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal static class ExtractTasks
    {
        private static ObservableCollection<TDTask> GetTasks(ObservableCollection<ToDoList> toDoList)
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

        public static ObservableCollection<TDTask> GetAllTasks(ObservableCollection<Category> categories)
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
