using SchoolManagementApp.ViewModels;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private Frame WindowContainer;

        private LoginWindowVM LoginWindowVM;

        private string connectionString;

        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            LoginWindowVM = new LoginWindowVM(connectionString);
            InitializeComponent();

            DataContext = LoginWindowVM;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindowVM.User.Role.AssignedRole == "Admin")
            {
                WindowContainer.Navigate(new AdminUserControl(WindowContainer, connectionString));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Teacher")
            {
                WindowContainer.Navigate(new TeacherUserControl(WindowContainer, connectionString));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Student")
            {
                WindowContainer.Navigate(new StudentUserControl(WindowContainer, connectionString));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Class master")
            {
                WindowContainer.Navigate(new ClassMasterUserControl(WindowContainer, connectionString));
            }
            LoginWindowVM.Email = string.Empty;
            LoginWindowVM.Password = string.Empty;
            LoginWindowVM.User = null;
        }
    }
}
