using SchoolManagementApp.ViewModels.AdminVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageSpecializationsAdminControl.xaml
    /// </summary>
    public partial class ManageSpecializationsAdminControl : UserControl
    {
        private readonly ManageSpecializationsVM manageSpecializationsVM;

        public ManageSpecializationsAdminControl(ManageSpecializationsVM manageSpecializationsVM)
        {
            this.manageSpecializationsVM = manageSpecializationsVM ?? throw new ArgumentNullException(nameof(manageSpecializationsVM));
            InitializeComponent();

            this.DataContext = manageSpecializationsVM;
        }
    }
}
