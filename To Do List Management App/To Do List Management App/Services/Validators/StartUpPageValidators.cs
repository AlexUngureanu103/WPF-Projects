using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.Services.Validators
{
    public static class StartUpPageValidators
    {
        public static bool CanAddTDL(ToDoList toDoList)
        {
            if (toDoList == null)
                return false;
            return true;
        }

        public static bool CanFindTasks(ObservableCollection<ToDoList> tdlLists)
        {
            if (ExtractTasks.GetTasks(tdlLists).Count == 0)
            {
                return false;
            }
            return true;
        }

        public static bool CanMoveUpDownTask(ToDoList selectedTDL, TDTask selectedTask)
        {
            if (selectedTDL == null || selectedTask == null)
            {
                return false;
            }
            return true;
        }
    }
}
