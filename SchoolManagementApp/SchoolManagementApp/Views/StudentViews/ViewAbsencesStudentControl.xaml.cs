using SchoolManagementApp.ViewModels.StudentVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for ViewAbsencesStudentControl.xaml
    /// </summary>
    public partial class ViewAbsencesStudentControl : UserControl
    {
        private readonly ViewAbsencesStudentVM viewAbsencesStudentVM;

        public ViewAbsencesStudentControl(ViewAbsencesStudentVM viewAbsencesStudentVM)
        {
            this.viewAbsencesStudentVM = viewAbsencesStudentVM ?? throw new ArgumentNullException(nameof(viewAbsencesStudentVM));

            InitializeComponent();

            DataContext = this.viewAbsencesStudentVM;
        }
    }
}
