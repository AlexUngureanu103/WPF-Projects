using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    public static class UpdateStatisticsPanel
    {
        public static StatisticsPanel UpdatedStatisticsPanel(ObservableCollection<ToDoList> categories)
        {
            StatisticsPanel statisticsPanel = new StatisticsPanel();
            var allTasks = ExtractTasks.GetTasks(categories);

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
                if (task.DueDate < DateTime.Now && (task.status != Enums.Status.Completed))
                {
                    statisticsPanel.TasksOverdue++;
                }
                else
                    if (task.status == Enums.Status.Completed && task.DueDate < task.FinishDate)
                {
                    statisticsPanel.FinishedLate++;
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
