using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageClasses.xaml
    /// </summary>
    public partial class ManageClasses : UserControl
    {
        private readonly ManageClassesVM manageClassesVM;

        public ManageClasses(ManageClassesVM manageClassesVM)
        {
            this.manageClassesVM = manageClassesVM ?? throw new ArgumentNullException(nameof(manageClassesVM));
            InitializeComponent();

            DataContext = manageClassesVM;
        }
    }
}
