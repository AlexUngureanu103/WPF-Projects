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

        private readonly string connectionString;

        private readonly AddUsersWindowVM addUsersWindowVM;

        public AddUsersWindow(Frame AdminControl, string connectionString)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            addUsersWindowVM = new AddUsersWindowVM(connectionString);

            DataContext = addUsersWindowVM;
        }
    }
}
