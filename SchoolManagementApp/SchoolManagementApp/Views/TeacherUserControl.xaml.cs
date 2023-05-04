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

        private readonly string connectionString;

        private TeacherUserControlVM TeacherUserControlVM;
        public TeacherUserControl(Frame windowContainer, string connectionString)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            TeacherUserControlVM = new TeacherUserControlVM(connectionString);

            DataContext = TeacherUserControlVM;
        }
    }
}
