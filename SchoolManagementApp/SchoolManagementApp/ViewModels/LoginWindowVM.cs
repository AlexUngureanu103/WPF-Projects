using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
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

        private ICommand displayAbout;
        public ICommand DisplayAbout
        {
            get
            {
                if(displayAbout == null)
                {
                    displayAbout = new RelayCommand(loginCommands.About);
                }
                return displayAbout;
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


        private ICommand adminLogin;
        public ICommand AdminLogin
        {
            get
            {
                if (adminLogin == null)
                {
                    adminLogin = new RelayCommand(LoginAsAdmin);
                }
                return adminLogin;
            }
        }

        private ICommand studentLogin;
        public ICommand StudentLogin
        {
            get
            {
                if (studentLogin == null)
                {
                    studentLogin = new RelayCommand(LoginAsStudent);
                }
                return studentLogin;
            }
        }

        private ICommand teacherLogin;
        public ICommand TeacherLogin
        {
            get
            {
                if (teacherLogin == null)
                {
                    teacherLogin = new RelayCommand(LoginAsTeacher);
                }
                return teacherLogin;
            }
        }
        private ICommand classMasterLogin;
        public ICommand ClassMasterLogin
        {
            get
            {
                if (classMasterLogin == null)
                {
                    classMasterLogin = new RelayCommand(LoginAsClassMaster);
                }
                return classMasterLogin;
            }
        }

        private void LoginAsStudent()
        {
            Email = "student@student.ro";
            Password = "student";
            CanLogin = true;
        }

        private void LoginAsTeacher()
        {
            Email = "teacher@teacher.ro";
            Password = "teacher";
            CanLogin = true;
        }

        private void LoginAsClassMaster()
        {
            Email = "classmaster@classmaster.ro";
            Password = "classmaster";
            CanLogin = true;
        }
    }
}
