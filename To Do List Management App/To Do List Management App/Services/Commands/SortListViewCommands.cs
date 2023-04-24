using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    public class SortListViewCommands
    {
        private StartUpPageVM startUpPageVM;

        private SortMethods sortMethods;

        public SortListViewCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            sortMethods = new SortMethods();
        }

        public void SortTasksByPriorityCommand()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByPriority(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksByDueDate()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByDueDate(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksName()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByName(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksDescription()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByDescription(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksStatus()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByStatus(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksCategory()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByCategory(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }

        public void SortTasksFinishDate()
        {
            if (startUpPageVM.SelectedToDoList != null)
            {
                startUpPageVM.SelectedToDoList.Tasks = sortMethods.SortTasksByFinishDate(startUpPageVM.SelectedToDoList.Tasks);
                startUpPageVM.SelectedToDoList = startUpPageVM.SelectedToDoList;
            }
        }
    }
}
