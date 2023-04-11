using System;
using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddToDoList : UserControl
    {
        private Frame WindowContainer;

        private StartUpPageVM startUpPageVM;
        public AddToDoList(Frame windowContainer, StartUpPageVM startUpPageVM, ToDoList selectedToDoList)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            InitializeComponent();

            DataContext = new AddToDoListVM(startUpPageVM , selectedToDoList);
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
