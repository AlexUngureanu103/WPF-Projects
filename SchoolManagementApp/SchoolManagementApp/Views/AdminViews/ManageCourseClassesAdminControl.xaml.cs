using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageCourseClassesAdminControl.xaml
    /// </summary>
    public partial class ManageCourseClassesAdminControl : UserControl
    {
        private readonly ManageCourseClassesVM manageCourseClassesVM;
        public ManageCourseClassesAdminControl(ManageCourseClassesVM manageCourseClassesVM)
        {
            this.manageCourseClassesVM = manageCourseClassesVM ?? throw new ArgumentNullException(nameof(manageCourseClassesVM));

            InitializeComponent();

            DataContext = this.manageCourseClassesVM;
        }
    }
}
