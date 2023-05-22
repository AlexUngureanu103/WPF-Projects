using SchoolManagementApp.ViewModels.AdminVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageTeachingMaterialsAdminUserControl.xaml
    /// </summary>
    public partial class ManageTeachingMaterialsAdminUserControl : UserControl
    {
        private readonly ManageTeachingMaterialsVM _manageTeachingMaterialsVM;

        public ManageTeachingMaterialsAdminUserControl(ManageTeachingMaterialsVM manageTeachingMaterialsVM)
        {
            _manageTeachingMaterialsVM = manageTeachingMaterialsVM ?? throw new ArgumentNullException(nameof(manageTeachingMaterialsVM));

            InitializeComponent();

            DataContext = _manageTeachingMaterialsVM;
        }
    }
}
