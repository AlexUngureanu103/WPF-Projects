using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class TaskValidator
    {
        public static bool CanExecuteAddTask(string taskName, string taskDescription, Priority taskPriority, string taskCategory, DateTime taskDueDate)
        {
            if (
                string.IsNullOrEmpty(taskCategory) ||
                taskPriority == Enums.Priority.None ||
                string.IsNullOrEmpty(taskName) ||
                string.IsNullOrEmpty(taskDescription) ||
                taskDueDate == null || taskDueDate < DateTime.Now
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
