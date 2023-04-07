using System.Windows.Controls;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for FindTaskWindowxaml.xaml
    /// </summary>
    public partial class FindTaskWindowxaml : UserControl
    {
        private FindTaskVM findTaskVM;

        public FindTaskWindowxaml(StartUpPageVM startUpPage)
        {
            findTaskVM = new FindTaskVM(startUpPage);
            InitializeComponent();
            DataContext = findTaskVM;
        }
    }
}
