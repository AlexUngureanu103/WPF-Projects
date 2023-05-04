using SchoolManagementApp.ViewModels;
using SchoolManagementApp.Views.AdminViews;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for AdminUserControl.xaml
    /// </summary>
    public partial class AdminUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly string connectionString;

        private AdminUserControlVM AdminUserControlVM;
        public AdminUserControl(Frame windowContainer, string connectionString)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            AdminUserControlVM = new AdminUserControlVM(connectionString);

            DataContext = AdminUserControlVM;
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(new AddUsersWindow(AdminControls, connectionString));
        }

        private void ManageClasses_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Class Page");
        }

        private void ManageTeachers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(new AddTeachersWindow(AdminControls, connectionString));
        }

        private void ManageClassMasters_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Class Master Page");
        }

        private void ManageStudents_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Student Page");
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowContainer.CanGoBack)
            {
                while (WindowContainer.CanGoBack)
                {
                    WindowContainer.RemoveBackEntry();
                }
                WindowContainer.Navigate(new LoginWindow(WindowContainer));
            }
            else
            {
                throw new ArgumentException("Invalid  navigation operation");
            }
        }
    }
}
