using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ViewRepeatersClassMasterControl.xaml
    /// </summary>
    public partial class ViewRepeatersClassMasterControl : UserControl
    {
        private readonly ViewRepeatersClassMasterVM ViewRepeatersClassMasterVM;

        public ViewRepeatersClassMasterControl(ViewRepeatersClassMasterVM viewTopClassMasterVM)
        {
            ViewRepeatersClassMasterVM = viewTopClassMasterVM ?? throw new ArgumentNullException(nameof(viewTopClassMasterVM));

            InitializeComponent();

            DataContext = ViewRepeatersClassMasterVM;
        }
    }
}
