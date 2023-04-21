using System;
using System.Windows;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class StartUpPageCommands
    {
        private StartUpPageVM startUpPageVM;

        public StartUpPageCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
        }

        public void DeleteToDoList()
        {
            if (!ConfirmAction())
            {
                return;
            }
            var parentTDL = GetParentOrRootTDL.GetParentOfSelectedTDL(startUpPageVM.RootToDoList, startUpPageVM.SelectedToDoList);
            if (parentTDL != startUpPageVM.SelectedToDoList)
            {
                parentTDL.toDoLists.Remove(startUpPageVM.SelectedToDoList);
            }
            else
            {
                startUpPageVM.RootToDoList.Remove(startUpPageVM.SelectedToDoList);
            }
            startUpPageVM.SelectedToDoList = null;
            startUpPageVM.SelectedTDTask = null;
        }

        private bool ConfirmAction()
        {
            var result = MessageBox.Show("Are you sure you want to perform this action?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.No)
                return false;
            return true;
        }

        public void DeleteTask()
        {
            if (!ConfirmAction())
            {
                return;
            }

            startUpPageVM.SelectedToDoList.Tasks.Remove(startUpPageVM.SelectedTDTask);
            startUpPageVM.SelectedTDTask = null;
        }

        public void MoveTaskUp()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTask);
            if (index > 0)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index - 1);
            }
        }

        public void MoveTaskDown()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTask);
            if (index < startUpPageVM.SelectedToDoList.Tasks.Count - 1)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index + 1);
            }
        }
    }
}
