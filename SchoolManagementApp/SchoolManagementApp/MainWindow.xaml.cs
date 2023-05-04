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
            //WindowContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            WindowContainer.Navigate(new LoginWindow(WindowContainer));
        }
    }
}
