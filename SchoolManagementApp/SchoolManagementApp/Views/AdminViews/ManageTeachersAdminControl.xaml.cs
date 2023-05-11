using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageTeachersAdminControl.xaml
    /// </summary>
    public partial class ManageTeachersAdminControl : UserControl
    {
        private readonly ManageTeachersVM manageTeachersVM;
        public ManageTeachersAdminControl(ManageTeachersVM manageTeachersVM)
        {
            this.manageTeachersVM = manageTeachersVM ?? throw new ArgumentNullException(nameof(manageTeachersVM));
            InitializeComponent();

            DataContext = this.manageTeachersVM;
        }
    }
}
