using SchoolManagementApp.DataAccess;
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

        private readonly LoginWindowVM loginWindowVM;
        public AdminUserControl(Frame windowContainer)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));

            InitializeComponent();
        }
    }
}
