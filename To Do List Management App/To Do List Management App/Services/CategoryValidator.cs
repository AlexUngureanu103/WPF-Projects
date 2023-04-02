namespace To_Do_List_Management_App.Services
{
    internal class CategoryValidator
    {

        public static bool CanExecuteAddCategory(string categoryName, string categoryDescription, string categoryImageSource)
        {
            if (string.IsNullOrEmpty(categoryName) || string.IsNullOrEmpty(categoryImageSource) || string.IsNullOrEmpty(categoryDescription))
            {
                return false;
            }
            return true;
        }
    }
}
