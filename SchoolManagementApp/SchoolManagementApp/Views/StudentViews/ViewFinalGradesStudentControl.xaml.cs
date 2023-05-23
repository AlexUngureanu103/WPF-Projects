using SchoolManagementApp.ViewModels.StudentVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for ViewFinalGradesStudentControl.xaml
    /// </summary>
    public partial class ViewFinalGradesStudentControl : UserControl
    {
        private readonly ViewFinalGradesStudentVM viewFinalGradesStudentVM;
        public ViewFinalGradesStudentControl(ViewFinalGradesStudentVM viewFinalGradesStudentVM)
        {
            this.viewFinalGradesStudentVM = viewFinalGradesStudentVM ?? throw new ArgumentNullException(nameof(viewFinalGradesStudentVM));

            InitializeComponent();

            this.DataContext = this.viewFinalGradesStudentVM;
        }
    }
}
