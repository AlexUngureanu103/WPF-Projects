﻿using SchoolManagementApp.Services.ApplicationLayer;
using SchoolManagementApp.ViewModels;
using SchoolManagementApp.Views.StudentViews;
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

        private readonly IUserControlFactory _userControlFactory;

        private readonly StudentUserControlVM studentUserControlVM;
        public StudentUserControl(Frame windowContainer, IUserControlFactory userControlFactory, StudentUserControlVM studentUserControlVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this._userControlFactory = userControlFactory ?? throw new ArgumentNullException(nameof(userControlFactory));
            this.studentUserControlVM = studentUserControlVM ?? throw new ArgumentNullException(nameof(studentUserControlVM));

            InitializeComponent();

            DataContext = this.studentUserControlVM;
        }

        private void Grades_Click(object sender, RoutedEventArgs e)
        {
            StudentControls.Navigate(_userControlFactory.Create<ViewGradesStudentControl>());
        }

        private void Absences_Click(object sender, RoutedEventArgs e)
        {
            StudentControls.Navigate(_userControlFactory.Create<ViewAbsencesStudentControl>());
        }

        private void Materials_Click(object sender, RoutedEventArgs e)
        {
            StudentControls.Navigate(_userControlFactory.Create<ViewMaterialsStudentControl>());
        }

        private void FinalGrades_Click(object sender, RoutedEventArgs e)
        {
            StudentControls.Navigate(_userControlFactory.Create<ViewFinalGradesStudentControl>());
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
