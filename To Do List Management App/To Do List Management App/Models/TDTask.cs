using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Models
{
    [Serializable]
    public class TDTask
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Priority priority { get; set; }

        public string Category { get; set; }

        public Status status { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
