using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.ToRegistribute
{
    internal class Task
    {
        public string Name { get; set; }

        public Priority priority { get; set; }

        public TaskType type { get; set; }

        public DateTime DueDate { get; set; }
    }
}
