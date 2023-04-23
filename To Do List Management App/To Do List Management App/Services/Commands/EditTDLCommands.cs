using System;
using To_Do_List_Management_App.ViewModels;
using To_Do_List_Management_App.Views;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class EditTDLCommands
    {
        private EditTDLVM editTDLVM;

        public EditTDLCommands(EditTDLVM editTDLVM)
        {
            this.editTDLVM = editTDLVM ?? throw new ArgumentNullException(nameof(editTDLVM));
        }

        public void PrevImageIndexCommand()
        {
            if (editTDLVM.TDLImageIndex == 0)
            {
                editTDLVM.TDLImageIndex = editTDLVM.TDLImageSources.Count - 1;
            }
            else
            {
                editTDLVM.TDLImageIndex--;
            }
        }

        public void NextImageIndexCommand()
        {
            if (editTDLVM.TDLImageIndex == editTDLVM.TDLImageSources.Count - 1)
            {
                editTDLVM.TDLImageIndex = 0;
            }
            else
            {
                editTDLVM.TDLImageIndex++;
            }
        }

        public void SaveTDLCommand()
        {
            editTDLVM.SelectedToDoList.Name = editTDLVM.TDLName;
            editTDLVM.SelectedToDoList.ImageSource = editTDLVM.TDLImageSource;

            editTDLVM.StartUpPageVM.startUpPageCommands.ArchiveCurrentData();
            editTDLVM.StartUpPageVM.startUpPageCommands.LoadArchivedData();
            editTDLVM.RootToDoList = editTDLVM.StartUpPageVM.RootToDoList;
        }

        public void MoveSelectedTDLToParent()
        {
            var parent = GetParentOrRootTDL.GetParentOfSelectedTDL(editTDLVM.RootToDoList, editTDLVM.SelectedToDoList);
            if (parent == editTDLVM.SelectedToDoList)
            {
                return;
            }
            var grandParent = GetParentOrRootTDL.GetParentOfSelectedTDL(editTDLVM.RootToDoList, parent);
            var selectedTDL = editTDLVM.SelectedToDoList;
            parent.toDoLists.Remove(editTDLVM.SelectedToDoList);
            if (grandParent == parent)
            {
                editTDLVM.RootToDoList.Add(selectedTDL);
            }
            else
            {
                grandParent.toDoLists.Add(selectedTDL);
            }
        }

        public void MoveSelectedTDLToChild()
        {
            var parent = GetParentOrRootTDL.GetParentOfSelectedTDL(editTDLVM.RootToDoList, editTDLVM.SelectedToDoList);
            var TDLList = parent.toDoLists;
            if (parent == editTDLVM.SelectedToDoList)
            {
                TDLList = editTDLVM.RootToDoList;
            }
            var selectedTDL = editTDLVM.SelectedToDoList;
            TDLList.Remove(editTDLVM.SelectedToDoList);

            CustomDialog customDialog = new CustomDialog(TDLList);
            customDialog.ShowDialog();
            var newParent = customDialog.customDialogVM.SelectedToDoList;

            if (newParent == null)
            {
                TDLList.Add(selectedTDL);
                return;
            }

            newParent.toDoLists.Add(selectedTDL);
        }

        public void MoveTDLUp()
        {
            var parent = GetParentOrRootTDL.GetParentOfSelectedTDL(editTDLVM.RootToDoList, editTDLVM.SelectedToDoList);
            int index;
            if (parent == editTDLVM.SelectedToDoList)
            {
                index = editTDLVM.RootToDoList.IndexOf(editTDLVM.SelectedToDoList);
                if (index > 0)
                {
                    editTDLVM.RootToDoList.Move(index, index - 1);
                }
            }
            else
            {
                index = parent.toDoLists.IndexOf(editTDLVM.SelectedToDoList);
                if (index > 0)
                {
                    parent.toDoLists.Move(index, index - 1);
                }
            }
        }

        public void MoveTDLDown()
        {
            var parent = GetParentOrRootTDL.GetParentOfSelectedTDL(editTDLVM.RootToDoList, editTDLVM.SelectedToDoList);
            int index;
            if (parent == editTDLVM.SelectedToDoList)
            {
                index = editTDLVM.RootToDoList.IndexOf(editTDLVM.SelectedToDoList);
                if (index < editTDLVM.RootToDoList.Count - 1)
                {
                    editTDLVM.RootToDoList.Move(index, index + 1);
                }
            }
            else
            {
                index = parent.toDoLists.IndexOf(editTDLVM.SelectedToDoList);
                if (index < parent.toDoLists.Count - 1)
                {
                    parent.toDoLists.Move(index, index + 1);
                }
            }
        }
    }
}
