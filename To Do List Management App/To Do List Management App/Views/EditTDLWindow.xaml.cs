using System;
using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for EditTDLWindow.xaml
    /// </summary>
    public partial class EditTDLWindow : UserControl
    {
        private Frame WindowContainer;

        private StartUpPageVM startUpPageVM;

        private StartUpWindow mainWindow;

        private EditTDLVM editTDLVM;

        public EditTDLWindow(Frame windowContainer, StartUpPageVM startUpPageVM, StartUpWindow mainWindow)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            this.startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            this.mainWindow = mainWindow;
            InitializeComponent();

            editTDLVM = new EditTDLVM(startUpPageVM);
            DataContext = editTDLVM;
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (WindowContainer.CanGoBack)
            {
                WindowContainer.GoBack();
                mainWindow.RootTreeView.InvalidateVisual();
            }
            else
            {
                throw new InvalidOperationException("Cannot navigate back, no pages in navigation history.");

            }
        }
    }
}