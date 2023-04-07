using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services
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
            //foreach (var task in findTaskVM.startUpPage.Categories)
            //{
            //    if (task.Name.Contains(findTaskVM.TaskName))
            //    {
            //        findTaskVM.FoundedTasks.Add(task);
            //    }
            //}
            return;
        }
    }
}
