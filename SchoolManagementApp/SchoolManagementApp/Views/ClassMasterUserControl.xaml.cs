using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for ClassMasterUserControl.xaml
    /// </summary>
    public partial class ClassMasterUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly SchoolManagementDbContext _dbContext;

        private ClassMasterUserControlVM ClassMasterUserControlVM;
        public ClassMasterUserControl(Frame windowContainer, SchoolManagementDbContext dbContext)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();

            ClassMasterUserControlVM = new ClassMasterUserControlVM(_dbContext);

            DataContext = ClassMasterUserControlVM;
        }
    }
}
