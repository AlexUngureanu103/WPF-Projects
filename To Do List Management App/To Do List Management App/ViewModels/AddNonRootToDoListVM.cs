using System;
using To_Do_List_Management_App.Models;

namespace To_Do_List_Management_App.ViewModels
{
    internal class AddNonRootToDoListVM : AddRootToDoListVM
    {
        private ToDoList selectedToDoList;
        public AddNonRootToDoListVM(StartUpPageVM startUpPageVM ,ToDoList selectedToDoList)
            :base(startUpPageVM)
        {
            this.selectedToDoList = selectedToDoList ?? throw new ArgumentNullException(nameof(selectedToDoList));
        }
    }
}
