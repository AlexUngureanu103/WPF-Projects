using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class FindTaskValidator
    {
        public static bool CanExecuteFindTask(string taskName, bool searchByName ,Priority taskPriority, bool searchByPriority, DateTime taskDueDate, bool searchByDueDate, Status status, bool searchByStatus, TaskType type, bool searchByType, bool searchByCompleted, bool searchByUnCompleted, bool searchByOverDue, bool searchByNotOverDue)
        {
            if (!searchByDueDate && !searchByName && !searchByPriority && !searchByStatus && !searchByType && !searchByCompleted && !searchByUnCompleted && !searchByOverDue && !searchByNotOverDue)
            {
                return false;
            }
            if (searchByName && string.IsNullOrEmpty(taskName))
            {
                return false;
            }
            if (searchByPriority && taskPriority == Priority.None)
            {
                return false;
            }
            if (searchByDueDate && taskDueDate == DateTime.MinValue)
            {
                return false;
            }
            if (searchByStatus && status == Status.None)
            {
                return false;
            }
            if (searchByType && type == TaskType.None)
            {
                return false;
            }
            return true;
        }
    }
}
