using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
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

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
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
                    addCommand = new RelayCommands<User>(Add, param => selectedUser == null);
                }
                return addCommand;
            }
        }

        private void Add(User user)
        {
            _userService.Add(user);
            ErrorMessage = _userService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<User>(Edit, param => selectedUser != null);
                }
                return updateCommand;
            }
        }

        private void Edit(User user)
        {
            _userService.Edit(user);
            ErrorMessage = _userService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<User>(Remove, param => selectedUser != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(User user)
        {
            _userService.Remove(user);
            ErrorMessage = _userService.errorMessage;
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            ErrorMessage = string.Empty;
            SelectedUser = null;
        }
    }
}
