using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.ViewModels.ManageUserVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for AddUsersWindow.xaml
    /// </summary>
    public partial class AddUsersWindow : UserControl
    {
        private readonly Frame AdminControl;

        private readonly SchoolManagementDbContext _dbContext;

        private readonly AddUsersWindowVM _addUsersWindowVM;

        private readonly AdminUserControlVM _adminUserControlVM;

        public AddUsersWindow(Frame AdminControl, SchoolManagementDbContext dbContext, AdminUserControlVM adminUserControlVM, User selectedUser)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this._adminUserControlVM = adminUserControlVM ?? throw new ArgumentNullException(nameof(adminUserControlVM));
            InitializeComponent();

            _addUsersWindowVM = new AddUsersWindowVM(_dbContext, adminUserControlVM, selectedUser);

            DataContext = _addUsersWindowVM;
        }
    }
}
