using SchoolManagementApp.ViewModels.AdminControls;
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
        private readonly ManageStudentsVM manageStudentsVM;

        public ManageStudentsAdminControl(ManageStudentsVM manageStudentsVM)
        {
            this.manageStudentsVM = manageStudentsVM ?? throw new ArgumentNullException(nameof(manageStudentsVM));
            InitializeComponent();

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
