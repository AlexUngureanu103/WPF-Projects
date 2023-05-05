using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.ManageStudentVMs;
using SchoolManagementApp.ViewModels.ManageUserVMs;
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
    /// Interaction logic for ManageStudentsAdminControl.xaml
    /// </summary>
    public partial class ManageStudentsAdminControl : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly ManageStudentsVM manageStudentsVM;

        public ManageStudentsAdminControl(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
            manageStudentsVM = new ManageStudentsVM(_dbContext);

            DataContext = manageStudentsVM;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
