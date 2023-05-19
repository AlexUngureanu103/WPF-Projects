using SchoolManagementApp.ViewModels.TeacherControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for ManageStudentsTeacherControl.xaml
    /// </summary>
    public partial class ManageStudentsTeacherControl : UserControl
    {
        private readonly ManageAverageGradesTeacherVM manageAverageGradesTeacherVM;
        public ManageStudentsTeacherControl(ManageAverageGradesTeacherVM manageAverageGradesTeacherVM)
        {
            this.manageAverageGradesTeacherVM = manageAverageGradesTeacherVM ?? throw new ArgumentNullException(nameof(manageAverageGradesTeacherVM));

            InitializeComponent();

            DataContext = manageAverageGradesTeacherVM;
        }
    }
}
