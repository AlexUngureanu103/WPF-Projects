using SchoolManagementApp.Services;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class TeacherUserControlVM : BaseVM
    {
        public readonly LoggedUser loggedUser;

        public TeacherUserControlVM(LoggedUser loggedUser)
        {
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));
        }
    }
}
