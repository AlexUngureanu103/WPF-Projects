using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
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

        private readonly AddUsersWindowVM addUsersWindowVM;

        public AddUsersWindow(Frame AdminControl, SchoolManagementDbContext dbContext, User selectedUser)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();

            addUsersWindowVM = new AddUsersWindowVM(_dbContext, selectedUser);

            DataContext = addUsersWindowVM;
        }
    }
}
