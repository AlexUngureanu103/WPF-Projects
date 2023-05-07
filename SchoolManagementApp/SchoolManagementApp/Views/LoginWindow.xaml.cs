using SchoolManagementApp.DataAccess;
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

        private readonly SchoolManagementDbContext _dbContext;

        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            _dbContext = new SchoolManagementDbContext(connectionString);
            LoginWindowVM = new LoginWindowVM(connectionString);
            InitializeComponent();
            DataContext = LoginWindowVM;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindowVM.User.Role.AssignedRole == "Admin")
            {
                WindowContainer.Navigate(new AdminUserControl(WindowContainer, _dbContext));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Teacher")
            {
                WindowContainer.Navigate(new TeacherUserControl(WindowContainer, _dbContext));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Student")
            {
                WindowContainer.Navigate(new StudentUserControl(WindowContainer, _dbContext));
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Class master")
            {
                WindowContainer.Navigate(new ClassMasterUserControl(WindowContainer, _dbContext));
            }
            UpdateMainWindowTitle($"School Management App - {LoginWindowVM.User.Role.AssignedRole} Control Panel");
            LoginWindowVM.Email = string.Empty;
            LoginWindowVM.Password = string.Empty;
            LoginWindowVM.User = null;
        }

        private void UpdateMainWindowTitle(string newTitle)
        {
            Window mainWindow = Window.GetWindow(this);
            if (mainWindow != null)
            {
                mainWindow.Title = newTitle;
            }
        }
    }
}
