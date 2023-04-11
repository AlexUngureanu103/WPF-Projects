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
    }
}
