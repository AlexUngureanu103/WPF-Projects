using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for StudentUserControl.xaml
    /// </summary>
    public partial class StudentUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly SchoolManagementDbContext _dbContext;

        private StudentUserControlVM StudentUserControlVM;
        public StudentUserControl(Frame windowContainer, SchoolManagementDbContext dbContext)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();

            StudentUserControlVM = new StudentUserControlVM(_dbContext);

            DataContext = StudentUserControlVM;
        }
    }
}
