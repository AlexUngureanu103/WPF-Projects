using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    internal class EditTaskCommands
    {
        private readonly EditTaskVM editTaskVM;

        public EditTaskCommands(EditTaskVM editTaskVM)
        {
            this.editTaskVM = editTaskVM ?? throw new ArgumentNullException(nameof(editTaskVM));
        }

        public void EditTask()
        {
            editTaskVM.startUpPageVM.SelectedTDTask.Name = editTaskVM.TaskName;
            editTaskVM.startUpPageVM.SelectedTDTask.Description = editTaskVM.TaskDescription;
            editTaskVM.startUpPageVM.SelectedTDTask.priority = editTaskVM.TaskPriority;
            editTaskVM.startUpPageVM.SelectedTDTask.Category = editTaskVM.TaskCategory;
            editTaskVM.startUpPageVM.SelectedTDTask.DueDate = editTaskVM.TaskDueDate;
            if (editTaskVM.TaskStatus == Enums.Status.Completed && editTaskVM.startUpPageVM.SelectedTDTask.status != Enums.Status.Completed)
            {
                editTaskVM.startUpPageVM.SelectedTDTask.FinishDate = DateTime.Now;
            }
            else if (editTaskVM.startUpPageVM.SelectedTDTask.status != Enums.Status.Completed)
            {
                editTaskVM.startUpPageVM.SelectedTDTask.FinishDate = DateTime.MinValue;
            }
            editTaskVM.startUpPageVM.SelectedTDTask.status = editTaskVM.TaskStatus;
        }
    }
}

