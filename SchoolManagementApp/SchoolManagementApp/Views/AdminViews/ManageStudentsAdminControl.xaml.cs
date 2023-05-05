﻿using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.AdminControls.ManageStudentVMs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageStudentsAdminControl.xaml
    /// </summary>
    public partial class ManageStudentsAdminControl : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly ManageStudentsVM manageStudentsVM;

        public ManageStudentsAdminControl(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
            manageStudentsVM = new ManageStudentsVM(_dbContext);

            DataContext = manageStudentsVM;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
