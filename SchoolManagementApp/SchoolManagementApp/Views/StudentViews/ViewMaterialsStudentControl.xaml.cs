using SchoolManagementApp.ViewModels.StudentVM;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.StudentViews
{
    /// <summary>
    /// Interaction logic for ViewMaterialsStudentControl.xaml
    /// </summary>
    public partial class ViewMaterialsStudentControl : UserControl
    {
        private readonly ViewMaterialsStudentVM viewMaterialsStudentVM;
        public ViewMaterialsStudentControl(ViewMaterialsStudentVM viewMaterialsStudentVM)
        {
            this.viewMaterialsStudentVM = viewMaterialsStudentVM ?? throw new ArgumentNullException(nameof(viewMaterialsStudentVM));

            InitializeComponent();

            this.DataContext = this.viewMaterialsStudentVM;
        }
    }
}
