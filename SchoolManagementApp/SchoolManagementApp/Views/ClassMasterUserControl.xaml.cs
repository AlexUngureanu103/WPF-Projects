using SchoolManagementApp.ViewModels;
using System;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for ClassMasterUserControl.xaml
    /// </summary>
    public partial class ClassMasterUserControl : UserControl
    {
        private readonly Frame WindowContainer;

        private readonly string connectionString;

        private ClassMasterUserControlVM ClassMasterUserControlVM;
        public ClassMasterUserControl(Frame windowContainer, string connectionString)
        {
            WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            this.connectionString = connectionString;
            InitializeComponent();

            ClassMasterUserControlVM = new ClassMasterUserControlVM(connectionString);

            DataContext = ClassMasterUserControlVM;
        }
    }
}
