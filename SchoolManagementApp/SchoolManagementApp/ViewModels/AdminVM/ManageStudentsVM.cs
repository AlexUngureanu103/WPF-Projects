using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageStudentsVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly IUserService _userService;

        private readonly IClassService _classService;

        private readonly IRoleRepository _roleRepository;

        public ManageStudentsVM(IStudentService studentService, IUserService userService, IClassService classService, IRoleRepository roleRepository)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));

            StudentList = _studentService.GetAll();
            UserList = _userService.GetUsersByRole(_roleRepository.GetByRole("Student").Id);
            ClassList = _classService.GetAll();
        }

        public ObservableCollection<Student> StudentList
        {
            get => _studentService.StudentList;
            set => _studentService.StudentList = value;
        }

        public ObservableCollection<User> UserList
        {
            get => _userService.UserList;
            set => _userService.UserList = value;
        }

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set => _classService.ClassList = value;
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Student>(_studentService.Add, param => selectedStudent == null);
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
                    updateCommand = new RelayCommands<Student>(_studentService.Edit, param => selectedStudent != null);
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
                    deleteCommand = new RelayCommands<Student>(_studentService.Remove, param => selectedStudent != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedStudent != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedStudent = null;
        }
    }
}
