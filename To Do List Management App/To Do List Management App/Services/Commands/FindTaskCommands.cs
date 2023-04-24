using System.Collections.ObjectModel;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class FindTaskCommands
    {
        private FindTaskVM findTaskVM;
        
        private SortMethods sortMethods;
        
        public FindTaskCommands(FindTaskVM findTaskVM)
        {
            this.findTaskVM = findTaskVM ?? throw new System.ArgumentNullException(nameof(findTaskVM));
            sortMethods = new SortMethods();
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
            if (findTaskVM.SearchByTaskCategory)
            {
                tasks = TaskSearchFilters.FindTasksByType(findTaskVM.TaskCategoryToFind, tasks);
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


        public void SortTasksByPriorityCommand()
        {
            if (findTaskVM.FoundedTasks.Count>0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByPriority(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksByDueDate()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByDueDate(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksName()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByName(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksDescription()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByDescription(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksStatus()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByStatus(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksCategory()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByCategory(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }

        public void SortTasksFinishDate()
        {
            if (findTaskVM.FoundedTasks.Count > 0)
            {
                findTaskVM.FoundedTasks = sortMethods.SortTasksByFinishDate(findTaskVM.FoundedTasks);
                findTaskVM.FoundedTasks = findTaskVM.FoundedTasks;
            }
        }
    }
}
