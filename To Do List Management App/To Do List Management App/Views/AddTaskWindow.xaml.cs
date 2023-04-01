using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.ToRegistribute;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : UserControl
    {
        public AddTaskWindow()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.WindowContainer.ClearValue(ContentControl.ContentProperty);
            mainWindow.WindowContainer.Navigate(new StartUpWindow());
        }
    }
}
