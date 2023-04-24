using System.Collections.ObjectModel;
using System.Linq;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal class TaskSortingAlgorithms
    {

        public static ObservableCollection<TDTask> SortByPriority(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.priority).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByPriorityReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.priority).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByDueDate(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.DueDate).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByDueDateReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.DueDate).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByName(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.Name).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByNameReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.Name).ToList());

            return foundedTasks;
        }
        public static ObservableCollection<TDTask> SortByDescription(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.Description).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByDescriptionReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.Description).ToList());

            return foundedTasks;
        }
        public static ObservableCollection<TDTask> SortByCategory(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.Category).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByCategoryReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.Category).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByStatus(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.status).ToList());

            return foundedTasks;
        }

        public static ObservableCollection<TDTask> SortByStatusReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.status).ToList());

            return foundedTasks;
        }
        public static ObservableCollection<TDTask> SortByFinishDate(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderBy(x => x.FinishDate).ToList());

            return foundedTasks;
        }
        public static ObservableCollection<TDTask> SortByFinishDateReverse(ObservableCollection<TDTask> tasksToFindIn)
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>(tasksToFindIn.OrderByDescending(x => x.FinishDate).ToList());

            return foundedTasks;
        }
    }
}
