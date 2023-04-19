using System;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class AddTaskCommands
    {
        private AddTaskVM AddTaskVM;

        public AddTaskCommands(AddTaskVM addTaskVM)
        {
            AddTaskVM = addTaskVM ?? throw new ArgumentNullException(nameof(addTaskVM));
        }

        public void BackCommand()
        {
            //AddTaskVM.NavigationService.NavigateTo("MainPage");
            return;
        }

        public void AddTaskCommand()
        {
            AddTaskVM.TaskToAdd = new TDTask()
            {
                Name = AddTaskVM.TaskName,
                Description = AddTaskVM.TaskDescription,
                priority = AddTaskVM.TaskPriority,
                type = AddTaskVM.TaskType,
                DueDate = AddTaskVM.TaskDueDate,
                status = Enums.Status.NotStarted,
                FinishDate = DateTime.MinValue
            };
            
            return;
        }
    }
}
