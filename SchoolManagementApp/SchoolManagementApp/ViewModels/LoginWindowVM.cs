using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services;
using SchoolManagementApp.Services.Validators;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class LoginWindowVM : BaseVM
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
                {
                    CredentialsOk = false;
                    AccountType = string.Empty;
                }
                else
                {
                    CredentialsOk = true;
                    AccountType = value.Role.AssignedRole;
                }
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

        private string accountType;
        public string AccountType
        {
            get { return "Account Type: " + accountType; }
            set
            {
                accountType = value;
                OnPropertyChanged();
            }
        }

        public LoginWindowVM(IUserRepository userRepository, IRoleRepository roleRepository, AuthorizationService authorizationService)
        {
            this.loginCommands = new LoginCommands(this, roleRepository, userRepository, authorizationService);

            LoginAsAdmin();
        }

        private void LoginAsAdmin()
        {
            Email = "admin@admin.ro";
            Password = "admin";
            CanLogin = true;
        }
    }
}
