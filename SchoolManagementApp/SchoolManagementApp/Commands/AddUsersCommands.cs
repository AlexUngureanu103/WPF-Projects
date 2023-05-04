using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels.ManageUserVM;
using System;
using System.Windows;

namespace SchoolManagementApp.Commands
{
    internal class AddUsersCommands
    {
        private readonly AddUsersWindowVM addUsersWindowVM;

        private readonly AuthorizationService authorizationService;

        private readonly IUserRepository _userRepository;

        public AddUsersCommands(AuthorizationService authorizationService, IUserRepository userRepository, AddUsersWindowVM addUsersWindowVM)
        {
            this.authorizationService = authorizationService ?? throw new ArgumentNullException(nameof(authorizationService));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.addUsersWindowVM = addUsersWindowVM ?? throw new ArgumentNullException(nameof(addUsersWindowVM));
        }

        public void AddUserCommand()
        {
            var user = _userRepository.GetByEmail(addUsersWindowVM.NewUserEmail);
            if (user != null)
            {
                MessageBox.Show("User with this email already exists", "Error");
                return;
            }

            user = new User
            {
                Email = addUsersWindowVM.NewUserEmail,
                PasswordHash = authorizationService.HashPassword(addUsersWindowVM.NewUserPassword),
                RoleId = addUsersWindowVM.NewUserRole.Id
            };

            _userRepository.Add(user);
        }
    }
}
