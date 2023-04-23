using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using To_Do_List_Management_App.ViewModels;

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
    }
}
