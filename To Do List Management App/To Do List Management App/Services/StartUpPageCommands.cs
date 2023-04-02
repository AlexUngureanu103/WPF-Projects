using System;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Services
{
    internal class StartUpPageCommands
    {

        private StartUpPageVM startUpPageVM;

        public StartUpPageCommands(StartUpPageVM startUpPageVM)
        {
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
        }
    }
}
