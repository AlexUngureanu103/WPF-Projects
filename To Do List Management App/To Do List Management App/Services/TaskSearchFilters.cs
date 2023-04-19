using System;
using System.Collections.ObjectModel;
using System.Linq;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal static class TaskSearchFilters
    {

        public static ObservableCollection<TDTask> FindTasksByName(string taskName, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => StringMatching.IsMatch(x.Name, taskName)));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindTasksByPriority(Priority priority, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => x.priority == priority));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindTasksByStatus(Status status, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => x.status == status));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindTasksByType(TaskType type, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => x.type == type));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindTasksByDueDate(DateTime dueDate, ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => DateTime.Compare(x.DueDate.Date, dueDate.Date) <= 0));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindCompletedTasks(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => x.status == Status.Completed));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindUnCompletedTasks(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => x.status != Status.Completed));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindOverDueTasks(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x => DateTime.Compare(x.DueDate, DateTime.Now) <= 0));

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> FindNotOverDueTasks(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.Where(x =>  DateTime.Compare(x.DueDate, DateTime.Now) > 0));

            return foundedTasks;
        }

    }
}
