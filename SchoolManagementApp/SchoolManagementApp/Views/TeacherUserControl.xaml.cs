using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for TeacherUserControl.xaml
    /// </summary>
    public partial class TeacherUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly LoggedUser loggedUser;

        private readonly TeacherUserControlVM TeacherUserControlVM;

        public TeacherUserControl(Frame windowContainer, LoggedUser loggedUser, TeacherUserControlVM teacherUserControlVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));

            TeacherUserControlVM = teacherUserControlVM ?? throw new ArgumentNullException(nameof(teacherUserControlVM));

            InitializeComponent();

            string userinfo = loggedUser.User.Email + " " + loggedUser.User.PasswordHash +
                '\n' + loggedUser.User.Role.AssignedRole +
                '\n' + loggedUser.User.Person.FirstName + " " + loggedUser.User.Person.LastName;
            MessageBox.Show($"Info {userinfo}");

            DataContext = TeacherUserControlVM;
        }
    }
}
