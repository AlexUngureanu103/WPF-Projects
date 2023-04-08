using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    public static class UpdateStatisticsPanel
    {
        public static StatisticsPanel UpdatedStatisticsPnael(ObservableCollection<Category> categories)
        {
            StatisticsPanel statisticsPanel = new StatisticsPanel();
            var allTasks = ExtractTasks.GetAllTasks(categories);

            foreach (TDTask task in allTasks)
            {
                statisticsPanel.TotalTasks++;
                if (task.status == Enums.Status.Completed)
                {
                    statisticsPanel.TasksCompleted++;
                }
                else
                {
                    statisticsPanel.UncompletedTasks++;
                }
                if (task.DueDate < System.DateTime.Now)
                {
                    statisticsPanel.TasksOverdue++;
                }
                if (task.DueDate.Date == System.DateTime.Today.Date)
                {
                    statisticsPanel.TasksDueToday++;
                }
                else if (task.DueDate.Date == System.DateTime.Today.AddDays(1))
                {
                    statisticsPanel.TasksDueTomorrow++;
                }
            }

            return statisticsPanel;
        }
    }
}
