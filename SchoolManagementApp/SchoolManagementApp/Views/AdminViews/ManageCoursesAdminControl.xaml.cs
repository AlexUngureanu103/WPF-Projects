using SchoolManagementApp.ViewModels.AdminVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageCoursesAdminControl.xaml
    /// </summary>
    public partial class ManageCoursesAdminControl : UserControl
    {
        private readonly ManageCoursesVM manageCourses;

        public ManageCoursesAdminControl(ManageCoursesVM manageCourses)
        {
            this.manageCourses = manageCourses ?? throw new ArgumentNullException(nameof(manageCourses));
            InitializeComponent();

            DataContext = manageCourses;
        }
    }
}
