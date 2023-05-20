using SchoolManagementApp.ViewModels.TeacherVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.TeacherViews
{
    /// <summary>
    /// Interaction logic for ManageMaterialsTeacherControl.xaml
    /// </summary>
    public partial class ManageMaterialsTeacherControl : UserControl
    {
        private readonly ManageTeachingMaterialsTeacherVM manageTeachingMaterialsTeacherVM;
        
        public ManageMaterialsTeacherControl(ManageTeachingMaterialsTeacherVM manageTeachingMaterialsTeacherVM)
        {
            this.manageTeachingMaterialsTeacherVM = manageTeachingMaterialsTeacherVM ?? throw new ArgumentNullException(nameof(manageTeachingMaterialsTeacherVM));
            InitializeComponent();

            DataContext = this.manageTeachingMaterialsTeacherVM;
        }
    }
}
