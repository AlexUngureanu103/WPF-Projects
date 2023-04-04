namespace To_Do_List_Management_App.Models
{
    public class StatisticsPanel
    {
        public int TotalTasks { get; set; }

        public int TasksCompleted { get; set; }

        public int TasksOverdue { get; set; }

        public int TasksDueTomorrow { get; set; }

        public int TasksDueToday { get; set; }

        public int UncompletedTasks { get; set; }
    }
}
