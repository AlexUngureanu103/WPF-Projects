using System.Collections.ObjectModel;
using System.Windows;
using To_Do_List_Management_App.Models;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for CustomDialog.xaml
    /// </summary>
    public partial class CustomDialog : Window
    {
        public CustomDialogVM customDialogVM;

        public CustomDialog(ObservableCollection<ToDoList> toDoLists)
        {
            customDialogVM = new CustomDialogVM(toDoLists);
            InitializeComponent();

            DataContext = customDialogVM;
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            customDialogVM.SelectedToDoList = null;
            this.Close();
        }
    }
}
