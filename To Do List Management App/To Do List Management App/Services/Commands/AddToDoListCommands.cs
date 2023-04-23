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
                Name = addToDoListVM.TDLName,
                ImageSource = addToDoListVM.TDLImageSource,
                Tasks = new ObservableCollection<TDTask>(),
                toDoLists = new ObservableCollection<ToDoList>()
            };
            return;
        }

        public void PrevImageIndexCommand()
        {
            if (addToDoListVM.TDLImageIndex == 0)
            {
                addToDoListVM.TDLImageIndex = addToDoListVM.TDLImageSources.Count - 1;
            }
            else
            {
                addToDoListVM.TDLImageIndex--;
            }
        }

        public void NextImageIndexCommand()
        {
            if (addToDoListVM.TDLImageIndex == addToDoListVM.TDLImageSources.Count - 1)
            {
                addToDoListVM.TDLImageIndex = 0;
            }
            else
            {
                addToDoListVM.TDLImageIndex++;
            }
        }
    }
}
