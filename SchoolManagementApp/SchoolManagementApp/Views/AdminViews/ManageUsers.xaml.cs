using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageUsers.xaml
    /// </summary>
    public partial class ManageUsers : UserControl
    {
        private readonly ManageUsersVM manageUsersVM;

        public ManageUsers(ManageUsersVM manageUsersVM)
        {
            this.manageUsersVM = manageUsersVM ?? throw new ArgumentNullException(nameof(manageUsersVM));

            InitializeComponent();

            DataContext = manageUsersVM;
        }
    }
}
