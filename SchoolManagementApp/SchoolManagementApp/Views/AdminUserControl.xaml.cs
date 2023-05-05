﻿using SchoolManagementApp.DataAccess;
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

        private readonly SchoolManagementDbContext _dbContext;

        private AdminUserControlVM AdminUserControlVM;
        public AdminUserControl(Frame windowContainer, SchoolManagementDbContext dbContext)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();

            AdminUserControlVM = new AdminUserControlVM(_dbContext);

            DataContext = AdminUserControlVM;
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(new AddUsersWindow(AdminControls, _dbContext, null));
        }

        private void ManageClasses_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Add Class Page");
        }

        private void ManageTeachers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(new AddTeachersWindow(AdminControls, _dbContext));
        }

        private void ManageClassMasters_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(new AddUsersWindow(AdminControls, _dbContext, AdminUserControlVM.SelectedUser));
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
