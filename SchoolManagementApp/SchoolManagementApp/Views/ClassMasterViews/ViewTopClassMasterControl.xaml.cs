using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ViewTopClassMasterControl.xaml
    /// </summary>
    public partial class ViewTopClassMasterControl : UserControl
    {
        private readonly ViewTopClassMasterVM viewTopClassMasterVM;
        public ViewTopClassMasterControl(ViewTopClassMasterVM viewTopClassMasterVM)
        {
            this.viewTopClassMasterVM = viewTopClassMasterVM ?? throw new ArgumentNullException(nameof(viewTopClassMasterVM));

            InitializeComponent();

            DataContext = this.viewTopClassMasterVM;
        }
    }
}
