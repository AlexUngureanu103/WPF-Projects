using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageAbsencesAdminControl.xaml
    /// </summary>
    public partial class ManageAbsencesAdminControl : UserControl
    {
        private readonly ManageAbsencesVM _manageAbsencesVM;
        public ManageAbsencesAdminControl(ManageAbsencesVM manageAbsencesVM)
        {
            this._manageAbsencesVM = manageAbsencesVM ?? throw new ArgumentNullException(nameof(manageAbsencesVM));
            InitializeComponent();

            DataContext = _manageAbsencesVM;
        }
    }
}
