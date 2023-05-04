using SchoolManagementApp.DataAccess;
using System;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    internal class AdminUserControlVM : BaseVM
    {
        public readonly SchoolManagementDbContext _dbContext;

        public AdminUserControlVM(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
