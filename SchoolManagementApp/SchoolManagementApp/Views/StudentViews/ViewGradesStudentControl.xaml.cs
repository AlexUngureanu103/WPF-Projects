using SchoolManagementApp.ViewModels.StudentVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for ViewGradesStudentControl.xaml
    /// </summary>
    public partial class ViewGradesStudentControl : UserControl
    {
        private readonly ViewGradesStudentVM viewGradesStudentVM;
        public ViewGradesStudentControl(ViewGradesStudentVM viewGradesStudentVM)
        {
            this.viewGradesStudentVM = viewGradesStudentVM ?? throw new ArgumentNullException(nameof(viewGradesStudentVM));

            InitializeComponent();

            this.DataContext = this.viewGradesStudentVM;
        }
    }
}
