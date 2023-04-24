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

        public int FinishedLate { get; set; }

        public override string ToString()
        {
            string value = string.Empty;
            value = "Tatal Tasks: " + TotalTasks + '\n';
            value += "Completed Tasks: " + TasksCompleted + '\n';
            value += "Uncompleted Tasks: " + UncompletedTasks + '\n';
            value += "OverDue Tasks: " + TasksOverdue + '\n';
            value += "Tasks Finished Late: " + FinishedLate + '\n';
            value += "Tasks Due Today: " + TasksDueToday + '\n';
            value += "Tasks Due Tomorrow: " + TasksDueTomorrow + '\n';
            return value;
        }
    }
}
