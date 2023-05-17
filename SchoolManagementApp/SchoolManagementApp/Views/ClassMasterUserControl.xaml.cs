using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for ClassMasterUserControl.xaml
    /// </summary>
    public partial class ClassMasterUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly LoggedUser loggedUser;

        private readonly ClassMasterUserControlVM ClassMasterUserControlVM;

        public ClassMasterUserControl(Frame windowContainer, LoggedUser loggedUser, ClassMasterUserControlVM classMasterUserControlVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));
            ClassMasterUserControlVM = classMasterUserControlVM ?? throw new ArgumentNullException(nameof(classMasterUserControlVM));

            InitializeComponent();

            string userinfo = loggedUser.User.Email + " " + loggedUser.User.PasswordHash +
                '\n' + loggedUser.User.Role.AssignedRole +
                '\n' + loggedUser.User.Person.FirstName + " " + loggedUser.User.Person.LastName;
            MessageBox.Show($"Info {userinfo}");

            DataContext = ClassMasterUserControlVM;
        }
    }
}
