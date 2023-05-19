using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ManageFinalGradesClassMasterControl.xaml
    /// </summary>
    public partial class ManageFinalGradesClassMasterControl : UserControl
    {
        private readonly ManageFinalGradesClassMasterVM manageFinalGradesClassMasterVM;

        public ManageFinalGradesClassMasterControl(ManageFinalGradesClassMasterVM manageFinalGradesClassMasterVM)
        {
            this.manageFinalGradesClassMasterVM = manageFinalGradesClassMasterVM ?? throw new ArgumentNullException(nameof(manageFinalGradesClassMasterVM));

            InitializeComponent();

            DataContext = this.manageFinalGradesClassMasterVM;
        }
    }
}
