using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.AdminControls;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManagePersonsAdminCrontrol.xaml
    /// </summary>
    public partial class ManagePersonsAdminCrontrol : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly ManagePersonsVM managePersonsVM;
        public ManagePersonsAdminCrontrol(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            managePersonsVM = new ManagePersonsVM(_dbContext);
            InitializeComponent();

            this.DataContext = managePersonsVM;
        }
    }
}
