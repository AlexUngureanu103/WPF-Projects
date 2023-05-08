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
    /// Interaction logic for ManageClasses.xaml
    /// </summary>
    public partial class ManageClasses : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly ManageClassesVM manageClassesVM;
        
        public ManageClasses(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            manageClassesVM = new ManageClassesVM(_dbContext);
            InitializeComponent();

            DataContext = manageClassesVM;
        }
    }
}
