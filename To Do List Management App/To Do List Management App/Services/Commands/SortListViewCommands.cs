using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    public class SortListViewCommands
    {
        private StartUpPageVM startUpPageVM;

        private bool isSortedByPriority = false;
        private bool isSortedByDueDate = false;
        private bool isSortedByName = false;
        private bool isSortedByDescription = false;
        private bool isSortedByStatus = false;
        private bool isSortedByFinishDate = false;
        private bool isSortedByCategory = false;
        
        public SortListViewCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
        }

        public void SortTasksByPriorityCommand()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByPriority)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByPriorityReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByPriority = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByPriority(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByPriority = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksByDueDate()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByDueDate)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByDueDate(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByDueDate = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByDueDateReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByDueDate = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksName()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByName)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByName(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByName = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByNameReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByName = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksDescription()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByDescription)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByDescription(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByDescription = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByDescriptionReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByDescription = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksStatus()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByStatus)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByStatus(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByStatus = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByStatusReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByStatus = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksCategory()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByCategory)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByCategory(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByCategory = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByCategoryReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByCategory = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksFinishDate()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                if (isSortedByFinishDate)
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByFinishDate(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByFinishDate = false;
                }
                else
                {
                    startUpPageVM.SelectedToDoList.Tasks = TaskSortingAlgorithms.SortByFinishDateReverse(startUpPageVM.SelectedToDoList.Tasks);
                    isSortedByFinishDate = true;
                }
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }
    }
}
