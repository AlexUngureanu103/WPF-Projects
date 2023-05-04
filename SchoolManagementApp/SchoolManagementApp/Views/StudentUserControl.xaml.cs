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

        private readonly string connectionString;

        private StudentUserControlVM StudentUserControlVM;
        public StudentUserControl(Frame windowContainer, string connectionString)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            StudentUserControlVM = new StudentUserControlVM(connectionString);

            DataContext = StudentUserControlVM;
        }
    }
}
