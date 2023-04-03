using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using To_Do_List_Management_App.ViewModels;

namespace To_Do_List_Management_App.Views
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : UserControl
    {
        private Frame WindowContainer;

        private StartUpPageVM startUpPageVM;
        public AddCategory(Frame windowContainer, StartUpPageVM startUpPageVM)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            startUpPageVM = startUpPageVM ?? throw new ArgumentNullException(nameof(startUpPageVM));
            InitializeComponent();

            DataContext = new AddCategoryVM(startUpPageVM);
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
