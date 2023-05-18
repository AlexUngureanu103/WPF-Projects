using SchoolManagementApp.ViewModels.TeacherControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for ManageAbsencesTeacherControl.xaml
    /// </summary>
    public partial class ManageAbsencesTeacherControl : UserControl
    {
        private readonly ManageAbsencesTeacherVM manageAbsencesTeacherVM;

        public ManageAbsencesTeacherControl(ManageAbsencesTeacherVM manageAbsencesTeacherVM)
        {
            this.manageAbsencesTeacherVM = manageAbsencesTeacherVM ?? throw new ArgumentNullException(nameof(manageAbsencesTeacherVM));

            InitializeComponent();

            DataContext = manageAbsencesTeacherVM;
        }
    }
}
