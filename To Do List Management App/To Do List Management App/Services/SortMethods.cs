using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal class SortMethods
    {
        private bool isSortedByPriority = false;
        private bool isSortedByDueDate = false;
        private bool isSortedByName = false;
        private bool isSortedByDescription = false;
        private bool isSortedByStatus = false;
        private bool isSortedByFinishDate = false;
        private bool isSortedByCategory = false;


        public ObservableCollection<TDTask> SortTasksByPriority(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByPriority)
            {
                isSortedByPriority = false;
                return TaskSortingAlgorithms.SortByDueDate(tasks);
            }
            else
            {
                isSortedByPriority = true;
                return TaskSortingAlgorithms.SortByDueDateReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByDueDate(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByDueDate)
            {
                isSortedByDueDate = false;
                return TaskSortingAlgorithms.SortByDueDate(tasks);
            }
            else
            {
                isSortedByDueDate = true;
                return TaskSortingAlgorithms.SortByDueDateReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByName(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByName)
            {
                isSortedByName = false;
                return TaskSortingAlgorithms.SortByName(tasks);
            }
            else
            {
                isSortedByName = true;
                return TaskSortingAlgorithms.SortByNameReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByDescription(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByDescription)
            {
                isSortedByDescription = false;
                return TaskSortingAlgorithms.SortByDescription(tasks);
            }
            else
            {
                isSortedByDescription = true;
                return TaskSortingAlgorithms.SortByDescriptionReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByStatus(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByStatus)
            {
                isSortedByStatus = false;
                return TaskSortingAlgorithms.SortByStatus(tasks);
            }
            else
            {
                isSortedByStatus = true;
                return TaskSortingAlgorithms.SortByStatusReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByCategory(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByCategory)
            {
                isSortedByCategory = false;
                return TaskSortingAlgorithms.SortByCategory(tasks);
            }
            else
            {
                isSortedByCategory = true;
                return TaskSortingAlgorithms.SortByCategoryReverse(tasks);
            }
        }

        public ObservableCollection<TDTask> SortTasksByFinishDate(ObservableCollection<TDTask> tasks)
        {
            if (isSortedByFinishDate)
            {
                isSortedByFinishDate = false;
                return TaskSortingAlgorithms.SortByFinishDate(tasks);
            }
            else
            {
                isSortedByFinishDate = true;
                return TaskSortingAlgorithms.SortByFinishDateReverse(tasks);
            }
        }
    }
}
