using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class FindTaskValidator
    {
        public static bool CanExecuteFindTask(string taskName, bool searchByName ,Priority taskPriority, bool searchByPriority, DateTime taskDueDate, bool searchByDueDate, Status status, bool searchByStatus, string taskCategory, bool searchByType, bool searchByCompleted, bool searchByUnCompleted, bool searchByOverDue, bool searchByNotOverDue)
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
            if (searchByType && string.IsNullOrEmpty(taskCategory))
            {
                return false;
            }
            return true;
        }
    }
}
