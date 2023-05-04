using SchoolManagementApp.DataAccess;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    internal class ClassMasterUserControlVM : BaseVM
    {
        public readonly SchoolManagementDbContext _dbContext;

        public ClassMasterUserControlVM(string connectionString)
        {
            _dbContext = new SchoolManagementDbContext(connectionString);
        }
    }
}
