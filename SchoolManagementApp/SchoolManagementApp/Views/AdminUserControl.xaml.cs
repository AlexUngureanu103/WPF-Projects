﻿using SchoolManagementApp.Services.ApplicationLayer;
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

        private readonly IUserControlFactory _userControlFactory;

        public AdminUserControl(Frame windowContainer, IUserControlFactory userControlFactory)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _userControlFactory = userControlFactory ?? throw new ArgumentNullException(nameof(userControlFactory));
            InitializeComponent();
        }

        private void ManageUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageUsers>());
        }

        private void ManageClasses_Click(object sender, RoutedEventArgs e)
        {

            AdminControls.Navigate(_userControlFactory.Create<ManageClasses>());
        }

        private void ManageTeachers_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageTeachersAdminControl>());
        }

        private void ManageStudents_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageStudentsAdminControl>());
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

        private void ManageSpecializations_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageSpecializationsAdminControl>());
        }

        private void ManageCourses_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageCoursesAdminControl>());
        }

        private void Specialization_Course_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageSpecializationCourseAdminControl>());
        }

        private void Person_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManagePersonsAdminCrontrol>());
        }

        private void CourseClass_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageCourseClassesAdminControl>());
        }
        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageGradesAdminControl>());
        }

        private void Absences_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageAbsencesAdminControl>());
        }

        private void TeachingClasses_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageTeachingClassesAdminControl>());
        }
        
        private void TeachingMaterial_Click(object sender, RoutedEventArgs e)
        {
            AdminControls.Navigate(_userControlFactory.Create<ManageTeachingMaterialsAdminUserControl>());
        }
    }
}

