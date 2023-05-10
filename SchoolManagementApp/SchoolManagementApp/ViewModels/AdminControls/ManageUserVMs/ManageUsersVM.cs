using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls.ManageUserVMs
{
    public class ManageUsersVM : BaseVM
    {
        private readonly IUserService _userService;

        private readonly IPersonService _personService;

        private readonly IRoleRepository _roleRepository;

        public ManageUsersVM(IUserService userService, IPersonService personService, IRoleRepository roleRepository)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));

            UserList = _userService.GetAll();
            PersonList = _personService.GetAll();
            RoleList = new ObservableCollection<Role>(_roleRepository.GetAll());
        }

        public ObservableCollection<Role> RoleList { get; }

        public ObservableCollection<User> UserList
        {
            get => _userService.UserList;
            set => _userService.UserList = value;
        }

        public ObservableCollection<Person> PersonList
        {
            get => _personService.PersonList;
            set => _personService.PersonList = value;
        }

        private User selectedUser;
        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<User>(_userService.Add, param => selectedUser == null);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<User>(_userService.Edit, param => selectedUser != null);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<User>(_userService.Remove, param => selectedUser != null);
                }
                return deleteCommand;
            }
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear, param => selectedUser != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedUser = null;
        }
    }
}
