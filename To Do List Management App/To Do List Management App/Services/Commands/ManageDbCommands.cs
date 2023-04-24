using System;
using System.Windows;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class ManageDbCommands
    {
        private LoadDBDialogVM manageDB;

        public ManageDbCommands(LoadDBDialogVM loadDBDialogVM)
        {
            this.manageDB = loadDBDialogVM ?? throw new ArgumentNullException(nameof(loadDBDialogVM));
        }

        public void DeleteSelectedDB()
        {
            MessageBoxResult result = MessageBox.Show("Are u sure u want to delete this DB ?","Warning" , MessageBoxButton.YesNo);
            if(result == MessageBoxResult.Yes)
            {
                manageDB.StartUpPageVM.startUpPageCommands.archiveData.DeleteDataBase(manageDB.SelectedDB);
                manageDB.DataBases.Remove(manageDB.SelectedDB);
            }
        }

        public void AddNewDb()
        {
            manageDB.StartUpPageVM.startUpPageCommands.archiveData.AddNewDataBase(manageDB.NewDb);
        }
    }
}
