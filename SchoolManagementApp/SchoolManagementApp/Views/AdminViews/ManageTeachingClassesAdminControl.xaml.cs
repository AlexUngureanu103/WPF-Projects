using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageTeachingClassesAdminControl.xaml
    /// </summary>
    public partial class ManageTeachingClassesAdminControl : UserControl
    {
        private readonly ManageTeachingClassesVM manageTeachersVM;

        public ManageTeachingClassesAdminControl(ManageTeachingClassesVM manageTeachersVM)
        {
            this.manageTeachersVM = manageTeachersVM ?? throw new ArgumentNullException(nameof(manageTeachersVM));
            InitializeComponent();

            DataContext = this.manageTeachersVM;
        }
    }
}
