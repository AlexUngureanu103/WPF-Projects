using System;
using System.Collections.ObjectModel;
using System.Windows;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for LoadDbDialog.xaml
    /// </summary>
    public partial class LoadDbDialog : Window
    {
        private LoadDBDialogVM loadDbDialogVM;

        public string SelectedDB;

        public LoadDbDialog(StartUpPageVM startUpPageVM,ObservableCollection<string> Databases)
        {
            InitializeComponent();
            loadDbDialogVM = new LoadDBDialogVM(startUpPageVM,Databases);

            DataContext = loadDbDialogVM;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            SelectedDB = null;
            this.Close();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            SelectedDB = loadDbDialogVM.SelectedDB;
            this.Close();
        }
    }
}
