using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManagePersonsAdminCrontrol.xaml
    /// </summary>
    public partial class ManagePersonsAdminCrontrol : UserControl
    {
        private readonly ManagePersonsVM managePersonsVM;

        public ManagePersonsAdminCrontrol(ManagePersonsVM managePersonsVM)
        {
            this.managePersonsVM = managePersonsVM ?? throw new ArgumentNullException(nameof(managePersonsVM));
            InitializeComponent();

            this.DataContext = managePersonsVM;
        }
    }
}
