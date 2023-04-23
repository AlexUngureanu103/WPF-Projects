using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services.Commands
{
    public class SortListViewCommands
    {
        private StartUpPageVM startUpPageVM;

        public SortListViewCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
        }

        public void SortTasksCommand()
        {
        }
    }
}
