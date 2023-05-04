using SchoolManagementApp.DataAccess;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    internal class StudentUserControlVM : BaseVM
    {
        public readonly SchoolManagementDbContext _dbContext;

        public StudentUserControlVM(string connectionString)
        {
            _dbContext = new SchoolManagementDbContext(connectionString);
        }
    }
}
