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

            findTaskVM.FoundedTasks = ApplyFilters(allTasks); ;
            return;
        }

        private ObservableCollection<TDTask> ApplyFilters(ObservableCollection<TDTask> tasks)
        {
            if (findTaskVM.SearchByName)
            {
                tasks = TaskSearchFilters.FindTasksByName(findTaskVM.NameToFind, tasks);
            }
            if (findTaskVM.SearchByDueDate)
            {
                tasks = TaskSearchFilters.FindTasksByDueDate(findTaskVM.DueDateToFind, tasks);
            }
            if (findTaskVM.SearchByPriority)
            {
                tasks = TaskSearchFilters.FindTasksByPriority(findTaskVM.PriorityToFind, tasks);
            }
            if (findTaskVM.SearchByTaskStatus)
            {
                tasks = TaskSearchFilters.FindTasksByStatus(findTaskVM.TaskStatusToFind, tasks);
            }
            if (findTaskVM.SearchByTaskType)
            {
                tasks = TaskSearchFilters.FindTasksByType(findTaskVM.TaskTypeToFind, tasks);
            }
            if (findTaskVM.SearchCompletedTasks)
            {
                tasks = TaskSearchFilters.FindCompletedTasks(tasks);
            }
            if (findTaskVM.SearchUncompletedTasks)
            {
                tasks = TaskSearchFilters.FindUnCompletedTasks(tasks);
            }
            if (findTaskVM.SearchOverDueTasks)
            {
                tasks = TaskSearchFilters.FindOverDueTasks(tasks);
            }
            if (findTaskVM.SearchNotOverDueTasks)
            {
                tasks = TaskSearchFilters.FindNotOverDueTasks(tasks);
            }
            return tasks;
        }
    }
}
