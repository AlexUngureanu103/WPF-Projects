using SchoolManagementApp.ViewModels.TeacherControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for ManageGradesTeacherControl.xaml
    /// </summary>
    public partial class ManageGradesTeacherControl : UserControl
    {
        private readonly ManagageGradesTeacherVM _gradesTeacherControl;

        public ManageGradesTeacherControl(ManagageGradesTeacherVM manageGradesTeacherControl)
        {
            _gradesTeacherControl = manageGradesTeacherControl ?? throw new ArgumentNullException(nameof(manageGradesTeacherControl));
            InitializeComponent();

            DataContext = _gradesTeacherControl;
        }
    }
}
