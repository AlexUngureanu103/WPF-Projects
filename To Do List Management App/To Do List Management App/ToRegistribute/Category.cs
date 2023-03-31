using System.Collections.Generic;

namespace To_Do_List_Management_App.ToRegistribute
{
    internal class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public List<ToDoList> ToDoLists { get; set; }
    }
}
