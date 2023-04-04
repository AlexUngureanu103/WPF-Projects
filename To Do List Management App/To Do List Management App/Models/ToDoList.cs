using System;
using System.Collections.ObjectModel;

namespace To_Do_List_Management_App.Models
{
    [Serializable]
    public class ToDoList
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public ObservableCollection<TDTask> Tasks { get; set; }

        public ObservableCollection<ToDoList> toDoLists { get; set; }
    }
}
