using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.ViewModels.AdminControls.ManageUserVMs;
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

        private readonly ManageUsersVM manageUsersVM;

        public AddUsersWindow(Frame AdminControl, SchoolManagementDbContext dbContext, ManageUsersVM manageUsersVM, User selectedUser)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.manageUsersVM = manageUsersVM ?? throw new ArgumentNullException(nameof(manageUsersVM));
            InitializeComponent();

            _addUsersWindowVM = new AddUsersWindowVM(_dbContext, manageUsersVM, selectedUser);

            DataContext = _addUsersWindowVM;
        }
    }
}
