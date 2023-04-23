using System;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace To_Do_List_Management_App.Models
{
    [Serializable]
    public class ToDoList
    {
        public string Name { get; set; }

        public string ImageSource { get; set; }

        public ObservableCollection<TDTask> Tasks { get; set; }

        [XmlIgnore]
        public ObservableCollection<ToDoList> toDoLists { get; set; }

        public ToDoList()
        {
            Tasks = new ObservableCollection<TDTask>();
            toDoLists = new ObservableCollection<ToDoList>();
        }
    }
}
