using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageTeachersVM : BaseVM
    {
        private readonly ITeacherService _teacherService;

        private readonly IUserService _userService;

        private readonly IRoleRepository _roleRepository;

        public ManageTeachersVM(ITeacherService teacherService, IUserService userService, IRoleRepository roleRepository)
        {
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            TeacherList = _teacherService.GetAll();
            UserList = new ObservableCollection<User>(_userService.GetAll().Where(c => c.RoleId != _roleRepository.GetByRole("Student").Id && c.RoleId != _roleRepository.GetByRole("Admin").Id));
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

        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherService.TeacherList;
            set => _teacherService.TeacherList = value;
        }

        public ObservableCollection<User> UserList
        {
            get => _userService.UserList;
            set => _userService.UserList = value;
        }

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Teacher>(Add, param => selectedTeacher == null);
                }
                return addCommand;
            }
        }

        private void Add(Teacher teacher)
        {
            _teacherService.Add(teacher);
            ErrorMessage = _teacherService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Teacher>(Edit, param => selectedTeacher != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Teacher teacher)
        {
            _teacherService.Edit(teacher);
            ErrorMessage = _teacherService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Teacher>(Remove, param => selectedTeacher != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Teacher teacher)
        {
            _teacherService.Remove(teacher);
            ErrorMessage = _teacherService.errorMessage;
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
            SelectedTeacher = null;
        }
    }
}
