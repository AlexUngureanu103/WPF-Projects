using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Repositories;
using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels
{
    public class AdminUserControlVM : BaseVM
    {
        public readonly SchoolManagementDbContext _dbContext;

        private readonly UserRepository userRepository;

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
                OnPropertyChanged();
            }
        }

        public AdminUserControlVM(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            userRepository = new UserRepository(_dbContext);
            Users = new ObservableCollection<User>(userRepository.GetAll());
        }
    }
}
