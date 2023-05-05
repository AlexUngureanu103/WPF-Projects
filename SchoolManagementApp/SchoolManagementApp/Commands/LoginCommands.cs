using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels;
using System;
using System.Windows;

namespace SchoolManagementApp.Commands
{
    internal class LoginCommands
    {
        private readonly IUserRepository _userRepository;

        private readonly IRoleRepository _roleRepository;

        private readonly LoginWindowVM _loginWindowVM;

        private readonly AuthorizationService authorizationService;

        public LoginCommands(LoginWindowVM loginWindowVM, IRoleRepository roleRepository, IUserRepository userRepository, AuthorizationService authorizationService)
        {
            this._loginWindowVM = loginWindowVM ?? throw new ArgumentNullException(nameof(loginWindowVM));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this._roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
        }

        public void Login()
        {
            var user = _userRepository.GetByEmail(_loginWindowVM.Email);
            if (user == null)
            {
                _loginWindowVM.User = null;
                return;
            }

            bool passwordFine = authorizationService.VerifyHashedPassword(user.PasswordHash, _loginWindowVM.Password);

            if (passwordFine)
            {
                user.Role = _roleRepository.GetById(user.RoleId);
                _loginWindowVM.User = user;
            }
            else
            {
                _loginWindowVM.User = null;
            }
            if (_loginWindowVM.User == null)
            {
                MessageBox.Show("Invalid credentials", "Error");
            }
            else
                _loginWindowVM.AccountType = _loginWindowVM.User.Role.AssignedRole;
        }
    }
}
