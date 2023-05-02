using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private Frame WindowContainer;

        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            InitializeComponent();
        }
    }
}
