using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for AddTeachersWindow.xaml
    /// </summary>
    public partial class AddTeachersWindow : UserControl
    {
        private readonly Frame AdminControl;

        private readonly string connectionString;

        public AddTeachersWindow(Frame AdminControl, string connectionString)
        {
            this.AdminControl = AdminControl ?? throw new ArgumentNullException(nameof(AdminControl));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();
        }
    }
}
