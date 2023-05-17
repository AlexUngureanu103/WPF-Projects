using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
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

        private readonly SchoolManagementDbContext _dbContext;

        private StudentUserControlVM StudentUserControlVM;

        private readonly User user;
        public StudentUserControl(Frame windowContainer, SchoolManagementDbContext dbContext, User user)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            InitializeComponent();

            StudentUserControlVM = new StudentUserControlVM(_dbContext);

            string userinfo = user.Email + " " + user.PasswordHash;
            MessageBox.Show($"Info {userinfo}");
            DataContext = StudentUserControlVM;
        }
    }
}
