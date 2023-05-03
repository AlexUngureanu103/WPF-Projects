using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Repositories;
using SchoolManagementApp.Services;
using System;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;

namespace SchoolManagementApp.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        private Frame WindowContainer;

        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            SchoolManagementDbContext schoolManagementDbContext = new SchoolManagementDbContext(connectionString);
            RoleRepository roleRepository = new RoleRepository(schoolManagementDbContext);
            CourseRepository courseRepository = new CourseRepository(schoolManagementDbContext);
            var result = courseRepository.GetAll();
            string s = "";
            foreach (var rol in result)
            {
                s += $"Role: {rol.Course}; Id:{rol.Id}\n";
            }
            MessageBox.Show(s);
            AuthorizationService autorizationService = new AuthorizationService();

            var pass = autorizationService.HashPassword("12345678");

            var ok = autorizationService.VerifyHashedPassword(pass, "12345678");
        }
    }
}
