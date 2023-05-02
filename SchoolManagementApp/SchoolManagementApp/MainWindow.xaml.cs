using SchoolManagementApp.Views;
using System.Windows;

namespace SchoolManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowContainer.Navigate(new LoginWindow(WindowContainer));
        }
    }
}
