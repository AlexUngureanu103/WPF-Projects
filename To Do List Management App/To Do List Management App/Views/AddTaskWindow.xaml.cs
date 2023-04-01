using System.Windows;
using System.Windows.Controls;
using To_Do_List_Management_App.Enums;
using To_Do_List_Management_App.ToRegistribute;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : UserControl
    {
        public TDTask task { get; set; }
        private Priority priority;

        public AddTaskWindow()
        {
            InitializeComponent();
            DataContext = this;
            task = new TDTask();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            priority = (Priority)PriorityComboBox.SelectedValue;
        }
    }
}
