using System.Windows;
using To_Do_List_Management_App.ResourceManagement;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoadImages loadImages;

        public MainWindow()
        {
            loadImages = new LoadImages(@"Images\CategoriesFolderIcons");
            InitializeComponent();
            WindowContainer.Navigate(new StartUpWindow(WindowContainer));
        }
    }
}
