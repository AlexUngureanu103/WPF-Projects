using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.Commands;
using To_Do_List_Management_App.Services.Commands;

namespace To_Do_List_Management_App.ViewModels
{
    internal class LoadDBDialogVM : BaseVM
    {
        public StartUpPageVM StartUpPageVM;

        private readonly ManageDbCommands manageDbCommands;

        private ObservableCollection<string> dataBases;
        public ObservableCollection<string> DataBases
        {
            get { return dataBases; }
            set
            {
                dataBases = value;
                OnPropertyChanged();
            }
        }

        private string selectedDB;
        public string SelectedDB
        {
            get { return selectedDB; }
            set
            {
                selectedDB = value;
                OnPropertyChanged();
            }
        }

        private string newDb;
        public string NewDb
        {
            get { return newDb; }
            set
            {
                newDb = value;
                OnPropertyChanged();
            }
        }

        private ICommand deleteDB;
        public ICommand DeleteDB
        {
            get
            {
                if (deleteDB == null)
                {
                    deleteDB = new RelayCommand(manageDbCommands.DeleteSelectedDB, param => selectedDB != null);
                }
                return deleteDB;
            }
        }

        private ICommand addDb;
        public ICommand AddNewDb
        {
            get
            {
                if (addDb == null)
                {
                    addDb = new RelayCommand(manageDbCommands.AddNewDb, param => !string.IsNullOrEmpty(newDb));
                }
                return addDb;
            }
        }

        public LoadDBDialogVM(StartUpPageVM startUpPageVM, ObservableCollection<string> Databases)
        {
            this.DataBases = Databases;
            this.StartUpPageVM = startUpPageVM;
            manageDbCommands = new ManageDbCommands(this);
        }
    }
}
