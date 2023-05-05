using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ManageStudentVMs
{
    internal class ManageStudentsVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly StudentRepository studentRepository;

        private readonly DeleteStudentsCommands deleteStudentsCommands;

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        private User selectedStudent;
        public User SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                if (selectedStudent != null)
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
                    deleteUser = new RelayCommand(deleteStudentsCommands.DeleteStudentCommand, param => SelectedStudent != null);
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


        public ManageStudentsVM(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            studentRepository = new StudentRepository(_dbContext);
            deleteStudentsCommands = new DeleteStudentsCommands(this, studentRepository);
            Students = new ObservableCollection<Student>(studentRepository.GetAll());
        }
    }
}
