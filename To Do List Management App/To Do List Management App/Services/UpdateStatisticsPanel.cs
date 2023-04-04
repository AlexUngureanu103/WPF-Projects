using System.Collections.Generic;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services
{
    internal class UpdateStatisticsPanel
    {
        StatisticsPanel statisticsPanel;

        public UpdateStatisticsPanel(StatisticsPanel statisticsPanel)
        {
            if (statisticsPanel == null)
            {
                statisticsPanel = new StatisticsPanel();
            }
            else
            {
                this.statisticsPanel = statisticsPanel;
            }
        }

        public StatisticsPanel UpdatedStatisticsPnael(IEnumerable<Category> categories)
        {
            statisticsPanel = new StatisticsPanel();

            foreach (Category category in categories)
            {
                foreach (ToDoList toDoList in category.ToDoLists)
                {
                    foreach (TDTask task in toDoList.Tasks)
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
                }
            }

            return statisticsPanel;
        }
    }
}
