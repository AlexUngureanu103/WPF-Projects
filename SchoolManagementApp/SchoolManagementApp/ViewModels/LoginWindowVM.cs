using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Repositories;
using SchoolManagementApp.Services;
using SchoolManagementApp.Services.Validators;
using System.Configuration;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    internal class LoginWindowVM : BaseVM
    {
        private readonly LoginCommands loginCommands;

        private bool canLogin;
        public bool CanLogin
        {
            get { return canLogin; }
            set { canLogin = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                CanLogin = LoginValidators.CanLogin(email, password);
                OnPropertyChanged();
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                CanLogin = LoginValidators.CanLogin(email, password);
                OnPropertyChanged();
            }
        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(loginCommands.Login, param => CanLogin);
                }
                return loginCommand;
            }
        }

        private User user;
        public User User
        {
            get { return user; }
            set
            {
                if (value == null)
                    CredentialsOk = false;
                else CredentialsOk = true;
                user = value;
                OnPropertyChanged();
            }
        }

        private bool credentialsOk;
        public bool CredentialsOk
        {
            get { return credentialsOk; }
            set
            {
                credentialsOk = value;
                OnPropertyChanged();
            }
        }

        public readonly SchoolManagementDbContext _dbContext;

        private readonly AuthorizationService authorizationService;

        public LoginWindowVM(string connectionString)
        {
            _dbContext = new SchoolManagementDbContext(connectionString);
            RoleRepository roleRepository = new RoleRepository(_dbContext);
            UserRepository userRepository = new UserRepository(_dbContext);
            AuthorizationService authorizationService = new AuthorizationService();
            loginCommands = new LoginCommands(this, roleRepository, userRepository, authorizationService);
        }
    }
}
