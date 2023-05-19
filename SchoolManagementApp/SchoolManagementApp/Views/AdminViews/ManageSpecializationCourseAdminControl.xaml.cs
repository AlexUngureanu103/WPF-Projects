using SchoolManagementApp.ViewModels.AdminVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageSpecializationCourseAdminControl.xaml
    /// </summary>
    public partial class ManageSpecializationCourseAdminControl : UserControl
    {
        private readonly ManageSpecializationCourseVM manageSpecializationCourseVM;

        public ManageSpecializationCourseAdminControl(ManageSpecializationCourseVM manageSpecializationCourseVM)
        {
            manageSpecializationCourseVM = manageSpecializationCourseVM ?? throw new ArgumentNullException(nameof(manageSpecializationCourseVM));
            InitializeComponent();

            DataContext = manageSpecializationCourseVM;
        }
    }
}
