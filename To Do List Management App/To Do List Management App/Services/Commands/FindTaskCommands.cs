using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class FindTaskCommands
    {
        private FindTaskVM findTaskVM;

        public FindTaskCommands(FindTaskVM findTaskVM)
        {
            this.findTaskVM = findTaskVM ?? throw new System.ArgumentNullException(nameof(findTaskVM));
        }

        public void BackCommand()
        {
            //AddCategoryVM.NavigationService.NavigateTo("MainPage");
            return;
        }

        public void FindTaskCommand()
        {
            ObservableCollection<TDTask> foundedTasks = new ObservableCollection<TDTask>();
            var allTasks = ExtractTasks.GetTasks(findTaskVM.startUpPage.RootToDoList);

            if (findTaskVM.SearchByName)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = TaskSearchFilters.FindTasksByName(findTaskVM.NameToFind, allTasks);
                }
            }
            if (findTaskVM.SearchByDueDate)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = TaskSearchFilters.FindTasksByDueDate(findTaskVM.DueDateToFind, allTasks);
                }
                else
                {
                    foundedTasks = TaskSearchFilters.FindTasksByDueDate(findTaskVM.DueDateToFind, foundedTasks);
                }
            }
            if (findTaskVM.SearchByPriority)
            {
                if (foundedTasks.Count == 0)
                {
                    foundedTasks = TaskSearchFilters.FindTasksByPriority(findTaskVM.PriorityToFind, allTasks);
                }
                else
                {
                    foundedTasks = TaskSearchFilters.FindTasksByPriority(findTaskVM.PriorityToFind, foundedTasks);
                }
            }

            findTaskVM.FoundedTasks = foundedTasks;
            return;
        }
    }
}
