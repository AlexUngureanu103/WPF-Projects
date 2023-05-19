using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ManageAbsencesClassMasterControl.xaml
    /// </summary>
    public partial class ManageAbsencesClassMasterControl : UserControl
    {
        private readonly ManageAbsencesClassMasterVM manageAbsencesClassMasterVM;

        public ManageAbsencesClassMasterControl(ManageAbsencesClassMasterVM manageAbsencesClassMasterVM)
        {
            this.manageAbsencesClassMasterVM = manageAbsencesClassMasterVM ?? throw new ArgumentNullException(nameof(manageAbsencesClassMasterVM));

            InitializeComponent();

            DataContext = manageAbsencesClassMasterVM;
        }
    }
}
