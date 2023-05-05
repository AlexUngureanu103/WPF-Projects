using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.ManageUserVM;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly ManageUsersVM manageUsersVM;

        public ManageUsers(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
            manageUsersVM = new ManageUsersVM(_dbContext);

            DataContext = manageUsersVM;
        }

        private void AddUsers_Click(object sender, RoutedEventArgs e)
        {
            ManageUsersFrame.Navigate(new AddUsersWindow(ManageUsersFrame, _dbContext, manageUsersVM, null));
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            ManageUsersFrame.Navigate(new AddUsersWindow(ManageUsersFrame, _dbContext, manageUsersVM, manageUsersVM.SelectedUser));
        }
    }
}
