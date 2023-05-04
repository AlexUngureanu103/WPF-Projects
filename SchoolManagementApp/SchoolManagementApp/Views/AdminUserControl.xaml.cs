using SchoolManagementApp.ViewModels;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for AdminUserControl.xaml
    /// </summary>
    public partial class AdminUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly string connectionString;

        private AdminUserControlVM AdminUserControlVM;
        public AdminUserControl(Frame windowContainer, string connectionString)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            AdminUserControlVM = new AdminUserControlVM(connectionString);

            DataContext = AdminUserControlVM;
        }
    }
}
