using System;
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
        }

        public void MoveTaskUp()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTast);
            if (index > 0)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index - 1);
            }
        }

        public void MoveTaskDown()
        {
            int index = startUpPageVM.SelectedToDoList.Tasks.IndexOf(startUpPageVM.SelectedTDTast);
            if (index < startUpPageVM.SelectedToDoList.Tasks.Count - 1)
            {
                startUpPageVM.SelectedToDoList.Tasks.Move(index, index + 1);
            }
        }
    }
}
