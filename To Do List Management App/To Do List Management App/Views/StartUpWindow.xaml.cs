using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : UserControl
    {
        public Frame WindowContainer { get; set; }

        public StartUpWindow(Frame windowContainer)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            InitializeComponent();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new AddTaskWindow(WindowContainer));
        }
    }
}
