using System;
using To_Do_List_Management_App.Enums;

namespace To_Do_List_Management_App.Services
{
    internal class FindTaskValidator
    {

        public static bool CanExecuteFindTask(string taskName, Priority taskPriority)
        {
            if (
                taskPriority == Enums.Priority.None ||
                string.IsNullOrEmpty(taskName)
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
