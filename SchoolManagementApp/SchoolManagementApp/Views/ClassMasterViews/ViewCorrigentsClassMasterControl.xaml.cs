using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ViewCorrigentsClassMasterControl.xaml
    /// </summary>
    public partial class ViewCorrigentsClassMasterControl : UserControl
    {
        private readonly ViewCorrigentsClassMasterVM ViewCorrigentsClassMasterVM;
        public ViewCorrigentsClassMasterControl(ViewCorrigentsClassMasterVM viewCorrigentsClassMasterVM)
        {
            ViewCorrigentsClassMasterVM = viewCorrigentsClassMasterVM ?? throw new ArgumentNullException(nameof(viewCorrigentsClassMasterVM));

            InitializeComponent();

            DataContext = ViewCorrigentsClassMasterVM;
        }
    }
}
