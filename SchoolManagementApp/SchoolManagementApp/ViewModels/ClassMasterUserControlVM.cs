using SchoolManagementApp.Services.ApplicationLayer;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class ClassMasterUserControlVM : BaseVM
    {
        private readonly LoggedUser loggedUser;
        public ClassMasterUserControlVM(LoggedUser user)
        {
            loggedUser = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
