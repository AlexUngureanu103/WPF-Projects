using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class FindTaskValidator
    {
        public static bool CanExecuteFindTask(string taskName, Priority taskPriority, DateTime taskDueDate, bool searchByName, bool searchByPriority, bool searchByDueDate)
        {
            if (!searchByDueDate && !searchByName && !searchByPriority)
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
            return true;
        }
    }
}
