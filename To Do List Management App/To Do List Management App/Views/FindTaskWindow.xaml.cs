using System;
using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for FindTaskWindowxaml.xaml
    /// </summary>
    public partial class FindTaskWindow : UserControl
    {
        private StartUpPageVM startUpPageVM;

        private FindTaskVM findTaskVM;

        private Frame WindowContainer;

        public FindTaskWindow(Frame windowContainer, StartUpPageVM startUpPage)
        {
            this.startUpPageVM = startUpPage ?? throw new ArgumentNullException(nameof(startUpPage));
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            findTaskVM = new FindTaskVM(startUpPage) ?? throw new ArgumentNullException(nameof(startUpPage));
            InitializeComponent();
            DataContext = findTaskVM;
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
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

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            WindowContainer.Navigate(new EditTaskWindow(WindowContainer,startUpPageVM, findTaskVM.SelectedTDTast));
        }
    }
}
