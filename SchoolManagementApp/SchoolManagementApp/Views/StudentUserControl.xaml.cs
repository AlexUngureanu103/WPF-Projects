using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for StudentUserControl.xaml
    /// </summary>
    public partial class StudentUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly LoggedUser loggedUser;

        private StudentUserControlVM StudentUserControlVM;

        public StudentUserControl(Frame windowContainer, StudentUserControlVM studentUserControlVM, LoggedUser loggedUser)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));
            StudentUserControlVM = studentUserControlVM ?? throw new ArgumentNullException(nameof(studentUserControlVM));

            InitializeComponent();

            string userinfo = loggedUser.User.Email + " " + loggedUser.User.PasswordHash + 
                '\n' + loggedUser.User.Role.AssignedRole + 
                '\n' + loggedUser.User.Person.FirstName + " " + loggedUser.User.Person.LastName;

            MessageBox.Show($" {userinfo}");
            DataContext = StudentUserControlVM;
        }
    }
}
