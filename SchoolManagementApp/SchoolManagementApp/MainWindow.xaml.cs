using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Views;
using System.Windows;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SchoolManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            InitializeComponent();
            //WindowContainer.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            log.Info("Application started ...");
            WindowContainer.Navigate(new LoginWindow(WindowContainer));
        }
    }
}
