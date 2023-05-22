using SchoolManagementApp.Services.Application;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class StudentUserControlVM : BaseVM
    {
        public readonly LoggedUser loggerUser;

        public StudentUserControlVM(LoggedUser user)
        {
            loggerUser = user ?? throw new System.ArgumentNullException(nameof(user));
        }
    }
}
