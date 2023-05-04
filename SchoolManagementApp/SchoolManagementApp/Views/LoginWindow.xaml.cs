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


        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            LoginWindowVM = new LoginWindowVM();
            InitializeComponent();

            DataContext = LoginWindowVM;
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindowVM.User.Role.AssignedRole == "Admin")
            {
                MessageBox.Show("U're an Admin");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Teacher")
            {
                MessageBox.Show("U're an Teacher");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Student")
            {
                MessageBox.Show("U're an Student");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Class master")
            {
                MessageBox.Show("U're an Class master");
            }
        }
    }
}
