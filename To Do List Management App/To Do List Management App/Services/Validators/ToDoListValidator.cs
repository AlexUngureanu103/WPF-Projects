using System.Collections.Generic;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class ToDoListValidator
    {

        public static bool CanExecuteAddCategory(string categoryName, List<string> tdlNames, string categoryImageSource)
        {
            if (tdlNames == null)
            {
                return false;
            }
            if (tdlNames.Contains(categoryName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryImageSource))
            {
                return false;
            }
            return true;
        }
    }
}
