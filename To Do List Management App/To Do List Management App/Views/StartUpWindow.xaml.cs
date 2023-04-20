using System;
using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for StartUpWindow.xaml
    /// </summary>
    public partial class StartUpWindow : UserControl
    {
        private StartUpPageVM _viewModel;
        public Frame WindowContainer { get; set; }

        public StartUpWindow(Frame windowContainer)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            _viewModel = new StartUpPageVM();
            InitializeComponent();

            DataContext = _viewModel;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.SelectedToDoList == null)
            {
                MessageBox.Show("Please select a list to add a task to.");
                return;
            }
            WindowContainer.Navigate(new AddTaskWindow(WindowContainer, _viewModel));
        }

        private void AddRootToDoListButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new AddToDoList(WindowContainer, _viewModel, null));
        }

        private void FindTaskButton_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new FindTaskWindow(WindowContainer, _viewModel));
        }

        private void AddToDoList_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new AddToDoList(WindowContainer, _viewModel, _viewModel.SelectedToDoList));
        }

        private void ManageCategory_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new ManageCategoryWindow(WindowContainer, _viewModel));
        }
    }
}
