using System.Windows;
using System.Windows.Controls;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : UserControl
    {
        public StartUpWindow()
        {
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.WindowContainer.Navigate(new AddTaskWindow());
        }
    }
}
