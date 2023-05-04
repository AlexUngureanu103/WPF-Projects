using SchoolManagementApp.ViewModels;
using System;
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

        private LoginWindowVM LoginWindowVM;

        public LoginWindow(Frame windowContainer)
        {
            this.WindowContainer = windowContainer ?? throw new ArgumentNullException(nameof(windowContainer));
            LoginWindowVM = new LoginWindowVM();
            InitializeComponent();

            DataContext = LoginWindowVM;
            //string connectionString = ConfigurationManager.ConnectionStrings["SchoolManagement"].ConnectionString;
            //SchoolManagementDbContext schoolManagementDbContext = new SchoolManagementDbContext(connectionString);
            //RoleRepository roleRepository = new RoleRepository(schoolManagementDbContext);
            //CourseRepository courseRepository = new CourseRepository(schoolManagementDbContext);
            //UserRepository userRepository = new UserRepository(schoolManagementDbContext);

            //AuthorizationService autorizationService = new AuthorizationService();

            ////User user = new User()
            ////{
            ////    Email = "admin@admin.ro",
            ////    Role = roleRepository.GetByRole("Admin"),
            ////    PasswordHash = autorizationService.HashPassword("admin")
            ////};
            ////userRepository.Add(user);

            //var result = userRepository.GetAll();
            //string s = "";
            //foreach (var rol in result)
            //{
            //    s += $"Email: {rol.Email}; passwordHash: {rol.PasswordHash}\n; role: {roleRepository.GetById(rol.RoleId).AssignedRole}";
            //}
            //MessageBox.Show(s);

            ////var pass = autorizationService.HashPassword("12345678");

            ////var ok = autorizationService.VerifyHashedPassword(pass, "12345678");
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (LoginWindowVM.User.Role.AssignedRole == "Admin")
            {
                MessageBox.Show("U're an Admin");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Teacher")
            {
                MessageBox.Show("U're an Teacher");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Student")
            {
                MessageBox.Show("U're an Student");
            }
            else if (LoginWindowVM.User.Role.AssignedRole == "Class master")
            {
                MessageBox.Show("U're an Class master");
            }
        }
    }
}
