using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.Services;
using SchoolManagementApp.ViewModels.AdminControls.ManageUserVMs;
using System;
using System.Windows;

namespace SchoolManagementApp.Commands
{
    internal class DeleteUserCommands
    {
        private readonly ManageUsersVM manageUsersVM;

        private readonly IUserRepository userRepository;

        public DeleteUserCommands(ManageUsersVM manageUsersVM, IUserRepository userRepository)
        {
            this.manageUsersVM = manageUsersVM ?? throw new ArgumentNullException(nameof(manageUsersVM));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public void DeleteUserCommand()
        {
            var result = MessageBox.Show($"Are u sure u want to delete User with Id: {manageUsersVM.SelectedUser.Id} ?", "Warning", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                userRepository.Delete(manageUsersVM.SelectedUser.Id);
                manageUsersVM.Users = new System.Collections.ObjectModel.ObservableCollection<DataAccess.Models.User>(userRepository.GetAll());
                manageUsersVM.SelectedUser = null;
            }
        }

        public void SortEntitiesById()
        {
            if (manageUsersVM.Users != null && manageUsersVM.Users.Count > 0)
            {
                manageUsersVM.Users = SortById.SortEntitiesById(manageUsersVM.Users);
            }
        }
    }
}
