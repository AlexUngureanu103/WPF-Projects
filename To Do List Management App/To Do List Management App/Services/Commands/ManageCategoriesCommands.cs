using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class ManageCategoriesCommands
    {
        private ManageCategoryVM manageCategoryVM;

        public ManageCategoriesCommands(ManageCategoryVM manageCategoryVM)
        {
            this.manageCategoryVM = manageCategoryVM ?? throw new ArgumentNullException(nameof(manageCategoryVM));
        }

        public void DeleteCategory()
        {
            manageCategoryVM.AvailableCategories.Remove(manageCategoryVM.SelectedCategory);
            manageCategoryVM.SelectedCategory = null;
        }

        public void AddCategory()
        {
            manageCategoryVM.AvailableCategories.Add(manageCategoryVM.CategoryToAdd);
        }
    }
}
