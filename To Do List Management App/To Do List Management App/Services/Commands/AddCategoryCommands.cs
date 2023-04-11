using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class AddCategoryCommands
    {
        private AddCategoryVM addCategoryVM;

        public AddCategoryCommands(AddCategoryVM addCategoryVM)
        {
            this.addCategoryVM = addCategoryVM ?? throw new ArgumentNullException(nameof(addCategoryVM));
        }

        public void BackCommand()
        {
            //AddCategoryVM.NavigationService.NavigateTo("MainPage");
            return;
        }

        public void AddCategoryCommand()
        {
            addCategoryVM.RootToDoListToAdd = new ToDoList()
            {
                Name = addCategoryVM.CategoryName,
                Description = addCategoryVM.CategoryDescription,
                ImageSource = addCategoryVM.CategoryImageSource,
                toDoLists = new ObservableCollection<ToDoList>()
            };
            return;
        }

        public void PrevImageIndexCommand()
        {
            if (addCategoryVM.CategoryImageIndex == 0)
            {
                addCategoryVM.CategoryImageIndex = addCategoryVM.CategoryImageSources.Count - 1;
            }
            else
            {
                addCategoryVM.CategoryImageIndex--;
            }
            addCategoryVM.CategoryImageSource = addCategoryVM.CategoryImageSources[addCategoryVM.CategoryImageIndex];
        }

        public void NextImageIndexCommand()
        {
            if (addCategoryVM.CategoryImageIndex == addCategoryVM.CategoryImageSources.Count - 1)
            {
                addCategoryVM.CategoryImageIndex = 0;
            }
            else
            {
                addCategoryVM.CategoryImageIndex++;
            }
            addCategoryVM.CategoryImageSource = addCategoryVM.CategoryImageSources[addCategoryVM.CategoryImageIndex];
        }
    }
}
