using SchoolManagementApp.DataAccess;
using SchoolManagementApp.ViewModels.AdminControls.ManageSpecializationVMs;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views.AdminViews
{
    /// <summary>
    /// Interaction logic for ManageSpecializationsAdminControl.xaml
    /// </summary>
    public partial class ManageSpecializationsAdminControl : UserControl
    {
        private readonly SchoolManagementDbContext _dbContext;

        private ManageSpecializationsVM manageSpecializationsVM;
        public ManageSpecializationsAdminControl(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
            manageSpecializationsVM = new ManageSpecializationsVM(dbContext);

            this.DataContext = manageSpecializationsVM;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteSpecialization_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
