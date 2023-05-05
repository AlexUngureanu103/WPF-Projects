using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ManageUserVMs
{
    public class ManageUsersVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly UserRepository userRepository;

        private readonly DeleteUserCommands deleteUsersCommands;

        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                if (selectedUser != null)
                {
                    CanEditUser = true;
                }
                else
                {
                    CanEditUser = false;
                }
                OnPropertyChanged();
            }
        }

        private ICommand deleteUser;
        public ICommand DeleteUser
        {
            get
            {
                if (deleteUser == null)
                {
                    deleteUser = new RelayCommand(deleteUsersCommands.DeleteUserCommand, param => SelectedUser != null);
                }
                return deleteUser;
            }
        }

        private bool canEditUser;
        public bool CanEditUser
        {
            get { return canEditUser; }
            set
            {
                canEditUser = value;
                OnPropertyChanged();
            }
        }


        public ManageUsersVM(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            userRepository = new UserRepository(_dbContext);
            deleteUsersCommands = new DeleteUserCommands(this, userRepository);
            Users = new ObservableCollection<User>(userRepository.GetAll());
        }
    }
}
