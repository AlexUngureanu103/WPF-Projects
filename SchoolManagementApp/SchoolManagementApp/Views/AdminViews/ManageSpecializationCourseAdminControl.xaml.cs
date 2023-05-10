using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageSpecializationCourseAdminControl.xaml
    /// </summary>
    public partial class ManageSpecializationCourseAdminControl : UserControl
    {
        private readonly ManageSpecializationCourseVM manageSpecializationCourseVM;

        public ManageSpecializationCourseAdminControl(ManageSpecializationCourseVM manageSpecializationCourseVM)
        {
            manageSpecializationCourseVM = manageSpecializationCourseVM ?? throw new ArgumentNullException(nameof(manageSpecializationCourseVM));
            InitializeComponent();

            DataContext = manageSpecializationCourseVM;
        }
    }
}
