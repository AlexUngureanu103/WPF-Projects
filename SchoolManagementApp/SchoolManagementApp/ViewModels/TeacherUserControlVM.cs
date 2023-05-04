using SchoolManagementApp.DataAccess;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    internal class TeacherUserControlVM : BaseVM
    {
        public readonly SchoolManagementDbContext _dbContext;

        public TeacherUserControlVM(string connectionString)
        {
            _dbContext = new SchoolManagementDbContext(connectionString);
        }
    }
}
