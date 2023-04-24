using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.ViewModels
{
    public class CustomDialogVM : BaseVM
    {
        private ObservableCollection<ToDoList> toDoLists;
        public ObservableCollection<ToDoList> ToDoLists
        {
            get { return toDoLists; }
            set
            {
                toDoLists = value;
                OnPropertyChanged();
            }
        }

        private ToDoList selectedToDoList;
        public ToDoList SelectedToDoList
        {
            get { return selectedToDoList; }
            set
            {
                selectedToDoList = value;
                OnPropertyChanged();
            }
        }

        public CustomDialogVM(ObservableCollection<ToDoList> toDoLists)
        {
            this.ToDoLists = toDoLists;
        }
    }
}
