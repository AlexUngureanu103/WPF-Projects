using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class AddToDoListCommands
    {
        private AddToDoListVM addToDoListVM;

        public AddToDoListCommands(AddToDoListVM addCategoryVM)
        {
            this.addToDoListVM = addCategoryVM ?? throw new ArgumentNullException(nameof(addCategoryVM));
        }

        public void BackCommand()
        {
            //AddCategoryVM.NavigationService.NavigateTo("MainPage");
            return;
        }

        public void AddRootToDoListCommand()
        {
            addToDoListVM.ToDoListToAdd = new ToDoList()
            {
                Name = addToDoListVM.CategoryName,
                Description = addToDoListVM.CategoryDescription,
                ImageSource = addToDoListVM.CategoryImageSource,
                Tasks = new ObservableCollection<TDTask>(),
                toDoLists = new ObservableCollection<ToDoList>()
            };
            return;
        }

        public void PrevImageIndexCommand()
        {
            if (addToDoListVM.CategoryImageIndex == 0)
            {
                addToDoListVM.CategoryImageIndex = addToDoListVM.CategoryImageSources.Count - 1;
            }
            else
            {
                addToDoListVM.CategoryImageIndex--;
            }
            addToDoListVM.CategoryImageSource = addToDoListVM.CategoryImageSources[addToDoListVM.CategoryImageIndex];
        }

        public void NextImageIndexCommand()
        {
            if (addToDoListVM.CategoryImageIndex == addToDoListVM.CategoryImageSources.Count - 1)
            {
                addToDoListVM.CategoryImageIndex = 0;
            }
            else
            {
                addToDoListVM.CategoryImageIndex++;
            }
            addToDoListVM.CategoryImageSource = addToDoListVM.CategoryImageSources[addToDoListVM.CategoryImageIndex];
        }
    }
}
