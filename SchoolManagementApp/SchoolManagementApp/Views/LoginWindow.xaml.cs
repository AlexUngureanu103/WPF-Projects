using SchoolManagementApp.Services.Application;
using SchoolManagementApp.ViewModels;
using System;
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

        private readonly IUserControlFactory _userControlFactory;

        private readonly LoggedUser loggedUser;

        public LoginWindow(Frame windowContainer, IUserControlFactory userControlFactory, LoginWindowVM loginWindow, LoggedUser user)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _userControlFactory = userControlFactory ?? throw new ArgumentNullException(nameof(userControlFactory));
            LoginWindowVM = loginWindow ?? throw new ArgumentNullException(nameof(loginWindow));
            this.loggedUser = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();
            DataContext = LoginWindowVM;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            loggedUser.User = LoginWindowVM.User;
            if (LoginWindowVM.User.Role.AssignedRole == "Admin")
            {
                WindowContainer.Navigate(_userControlFactory.Create<AdminUserControl>());
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Student")
            {
                WindowContainer.Navigate(_userControlFactory.Create<StudentUserControl>());
            }
            else /*if (LoginWindowVM.User.Role.AssignedRole == "Teacher")*/
            {
                WindowContainer.Navigate(_userControlFactory.Create<TeacherUserControl>());
            }
            //else
            //{
            //    WindowContainer.Navigate(_userControlFactory.Create<ClassMasterUserControl>());
            //}
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
