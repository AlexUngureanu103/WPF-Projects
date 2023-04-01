using To_Do_List_Management_App.ToRegistribute;

namespace To_Do_List_Management_App.Services
{
    internal class TaskValidator
    {
        public static bool CanExecuteAddTask(TDTask task)
        {
            if (task == null ||
                task.type == Enums.TaskType.None ||
                task.priority == Enums.Priority.None ||
                string.IsNullOrEmpty(task.Name) ||
                string.IsNullOrEmpty(task.Description) ||
                task.DueDate == null
                )
            {
                return false;
            }
            else
            {
                if (task.status == Enums.Status.None)
                    task.status = Enums.Status.NotStarted;
                return true;
            }
        }
    }
}
