using System;
using System.Windows;
using System.Windows.Controls;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : UserControl
    {
        public Frame WindowContainer { get; set; }

        public AddTaskWindow(Frame windowContainer)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            InitializeComponent();
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
