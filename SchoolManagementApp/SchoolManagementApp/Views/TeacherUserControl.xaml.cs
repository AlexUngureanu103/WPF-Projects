using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for TeacherUserControl.xaml
    /// </summary>
    public partial class TeacherUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly SchoolManagementDbContext _dbContext;

        private TeacherUserControlVM TeacherUserControlVM;
        public TeacherUserControl(Frame windowContainer, SchoolManagementDbContext dbContext)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();

            TeacherUserControlVM = new TeacherUserControlVM(dbContext);

            DataContext = TeacherUserControlVM;
        }
    }
}
