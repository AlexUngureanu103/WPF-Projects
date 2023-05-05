using SchoolManagementApp.DataAccess;
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
        public ManageSpecializationsAdminControl(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            InitializeComponent();
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
