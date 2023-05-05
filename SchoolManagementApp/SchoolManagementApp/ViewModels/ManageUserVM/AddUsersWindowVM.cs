using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Repositories;
using SchoolManagementApp.Services;
using SchoolManagementApp.Services.Validators;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ManageUserVM
{
    internal class AddUsersWindowVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        public readonly RoleRepository _roleRepository;

        private readonly AddUsersCommands addUsersCommands;

        private bool canAddUser;
        public bool CanAddUser
        {
            get { return canAddUser; }
            set
            {
                canAddUser = value;
            }
        }

        private string newUserEmail;
        public string NewUserEmail
        {
            get { return newUserEmail; }
            set
            {
                newUserEmail = value;
                CanAddUser = UsersValidators.ValidateNewUser(newUserEmail, newUserPassword, newUserRole);
                OnPropertyChanged();
            }
        }

        private string newUserPassword;
        public string NewUserPassword
        {
            get { return newUserPassword; }
            set
            {
                newUserPassword = value;
                CanAddUser = UsersValidators.ValidateNewUser(newUserEmail, newUserPassword, newUserRole);
                OnPropertyChanged();
            }
        }

        private Role newUserRole;
        public Role NewUserRole
        {
            get { return newUserRole; }
            set
            {
                newUserRole = value;
                CanAddUser = UsersValidators.ValidateNewUser(newUserEmail, newUserPassword, newUserRole);
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Role> roles;
        public ObservableCollection<Role> Roles
        {
            get { return roles; }
            set
            {
                roles = value;
                OnPropertyChanged();
            }
        }

        private ICommand addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (addUserCommand == null)
                {
                    if (selectedUser != null)
                    {
                        addUserCommand = new RelayCommand(addUsersCommands.EditUserCommand, param => canAddUser);
                    }
                    else
                    {
                        addUserCommand = new RelayCommand(addUsersCommands.AddUserCommand, param => canAddUser);
                    }
                }
                return addUserCommand;
            }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged();
            }
        }

        public User selectedUser;

        public AddUsersWindowVM(SchoolManagementDbContext dbContext, User selectedUser)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _roleRepository = new RoleRepository(_dbContext);
            Roles = new ObservableCollection<Role>(_roleRepository.GetAll());
            AuthorizationService authorizationService = new AuthorizationService();
            UserRepository userRepository = new UserRepository(_dbContext);
            addUsersCommands = new AddUsersCommands(authorizationService, userRepository, this);
            this.selectedUser = selectedUser;
            if (selectedUser != null)
            {
                ButtonContent = "Edit User";
                NewUserEmail = selectedUser.Email;
                NewUserRole = _roleRepository.GetById(selectedUser.RoleId);
            }
            else
            {
                ButtonContent = "Add User";
            }
        }
    }
}
