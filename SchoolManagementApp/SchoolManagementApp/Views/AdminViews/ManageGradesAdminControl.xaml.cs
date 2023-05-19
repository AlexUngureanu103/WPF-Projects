using SchoolManagementApp.ViewModels.AdminVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageGradesAdminControl.xaml
    /// </summary>
    public partial class ManageGradesAdminControl : UserControl
    {
        private readonly ManageGradesVM _manageGradesVM;
        public ManageGradesAdminControl(ManageGradesVM manageGradesVM)
        {
            this._manageGradesVM = manageGradesVM ?? throw new ArgumentNullException(nameof(manageGradesVM));
            InitializeComponent();

            DataContext = _manageGradesVM;
        }
    }
}
