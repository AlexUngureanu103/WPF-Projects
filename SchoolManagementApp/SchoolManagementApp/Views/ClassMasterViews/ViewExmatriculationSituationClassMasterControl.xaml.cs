using SchoolManagementApp.ViewModels.ClassMasterVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.ClassMasterViews
{
    /// <summary>
    /// Interaction logic for ViewExmatriculationSituationClassMasterControl.xaml
    /// </summary>
    public partial class ViewExmatriculationSituationClassMasterControl : UserControl
    {
        private readonly ViewExmatriculationSituationClassMasterVM viewExmatriculationSituation;

        public ViewExmatriculationSituationClassMasterControl(ViewExmatriculationSituationClassMasterVM viewExmatriculationSituation)
        {
            this.viewExmatriculationSituation = viewExmatriculationSituation ?? throw new ArgumentNullException(nameof(viewExmatriculationSituation));

            InitializeComponent();

            DataContext = this.viewExmatriculationSituation;
        }
    }
}
