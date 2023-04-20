using System.Collections.ObjectModel;

namespace To_Do_List_Management_App.Services.Validators
{
    internal class ManagaCategoryValidators
    {
        public static bool IsCategoryNameValid(string categoryName, ObservableCollection<string> categories)
        {
            if (categories.Contains(categoryName))
                return false;

            return !string.IsNullOrWhiteSpace(categoryName);
        }
    }
}
