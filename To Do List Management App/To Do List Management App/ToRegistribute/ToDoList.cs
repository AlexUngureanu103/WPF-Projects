using System;
using System.Collections.Generic;

namespace To_Do_List_Management_App.ToRegistribute
{
    [Serializable]
    public class ToDoList
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public List<TDTask> Tasks { get; set; }
    }
}
