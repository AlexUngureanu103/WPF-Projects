using SchoolManagementApp.ViewModels.AdminVM;
using System;
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
    }
}
