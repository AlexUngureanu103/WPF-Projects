﻿using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.Views.TeacherViews;
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

        private readonly TeacherUserControlVM TeacherUserControlVM;

        private readonly IUserControlFactory _userControlFactory;

        public TeacherUserControl(Frame windowContainer, IUserControlFactory userControlFactory, TeacherUserControlVM teacherUserControlVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _userControlFactory = userControlFactory ?? throw new ArgumentNullException(nameof(userControlFactory));

            TeacherUserControlVM = teacherUserControlVM ?? throw new ArgumentNullException(nameof(teacherUserControlVM));

            InitializeComponent();

            //string userinfo = loggedUser.User.Email + " " + loggedUser.User.PasswordHash +
            //    '\n' + loggedUser.User.Role.AssignedRole +
            //    '\n' + loggedUser.User.Person.FirstName + " " + loggedUser.User.Person.LastName;
            //MessageBox.Show($"Info {userinfo}");

            DataContext = TeacherUserControlVM;
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageGradesTeacherControl>());
        }

        private void Absences_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageAbsencesTeacherControl>());
        }
        private void Students_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageStudentsTeacherControl>());
        }
        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            TeacherControls.Navigate(_userControlFactory.Create<ManageMaterialsTeacherControl>());
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (WindowContainer.CanGoBack)
            {
                while (WindowContainer.CanGoBack)
                {
                    WindowContainer.RemoveBackEntry();
                }
                WindowContainer.Navigate(_userControlFactory.Create<LoginWindow>());
            }
            else
            {
                throw new ArgumentException("Invalid  navigation operation");
            }
        }
    }
}
