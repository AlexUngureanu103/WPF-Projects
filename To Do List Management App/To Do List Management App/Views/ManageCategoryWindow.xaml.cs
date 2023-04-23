using System;
using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for ManageCategoryWindow.xaml
    /// </summary>
    public partial class ManageCategoryWindow : UserControl
    {
        private Frame WindowContainer;

        public ManageCategoryWindow(Frame windowContainer, StartUpPageVM startUpPageVM)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            InitializeComponent();

            DataContext = new ManageCategoryVM(startUpPageVM);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (WindowContainer.CanGoBack)
            {
                WindowContainer.GoBack();
            }
            else
            {
                throw new InvalidOperationException("Cannot navigate back, no pages in navigation history.");
            }
        }
    }
}
