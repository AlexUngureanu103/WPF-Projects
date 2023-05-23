using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.TeacherVM
{
    public class ManageAbsencesTeacherVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly IAbsencesService _absenceService;

        private readonly ICourseService _courseService;

        private readonly ICourseClassTeacherService _courseClassTeacherService;

        private readonly ITeacherService _teacherService;

        private readonly LoggedUser loggedUser;

        private readonly Teacher teacher;

        public ManageAbsencesTeacherVM(IStudentService studentService, IAbsencesService absenceService, ICourseService courseService, ICourseClassTeacherService courseClassTeacherService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._absenceService = absenceService ?? throw new ArgumentNullException(nameof(absenceService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._courseClassTeacherService = courseClassTeacherService ?? throw new ArgumentNullException(nameof(courseClassTeacherService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));


            teacher = _teacherService.GetTeacherById(this.loggedUser.User.Id);
            TeachingClassesList = _courseClassTeacherService.GetTeachingClasses(teacher.Id);

            StudentList = _studentService.GetAll();
            AbsenceList = _absenceService.GetAll();
            CourseList = _courseService.GetAll();
            Semesters = new List<int> { 1, 2 };
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

        public ObservableCollection<CourseClassTeacher> TeachingClassesList
        {
            get => _courseClassTeacherService.CourseTeacherList;
            set => _courseClassTeacherService.CourseTeacherList = value;
        }

        private CourseClassTeacher selectedTeachingClass;
        public CourseClassTeacher SelectedTeachingClass
        {
            get => selectedTeachingClass;
            set
            {
                selectedTeachingClass = value;
                OnPropertyChanged(nameof(SelectedTeachingClass));
                if (selectedTeachingClass != null)
                {
                    var studentsFromClass = _studentService.GetStudentsByClassId(selectedTeachingClass.CourseClass.ClassId);
                    CourseList = new ObservableCollection<CourseType>{
                        selectedTeachingClass.CourseClass.CourseType
                    };
                    StudentList = new ObservableCollection<Student>(studentsFromClass);
                }
            }
        }

        public ObservableCollection<Absences> AbsenceList
        {
            get => _absenceService.AbsenceList;
            set
            {
                _absenceService.AbsenceList = value;
                OnPropertyChanged(nameof(AbsenceList));
            }
        }

        public ObservableCollection<Student> StudentList
        {
            get => _studentService.StudentList;
            set
            {
                _studentService.StudentList = value;
                OnPropertyChanged(nameof(StudentList));
            }
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set
            {
                _courseService.CourseList = value;
                OnPropertyChanged(nameof(CourseList));
            }
        }

        private List<int> semesters;
        public List<int> Semesters
        {
            get { return semesters; }
            set
            {
                semesters = value;
                OnPropertyChanged(nameof(Semesters));
            }
        }

        private Absences selectedAbsence;
        public Absences SelectedAbsence
        {
            get { return selectedAbsence; }
            set
            {
                selectedAbsence = value;
                OnPropertyChanged(nameof(SelectedAbsence));
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                if (selectedTeachingClass != null)
                    AbsenceList = _absenceService.GetStudentAbsences(selectedStudent, selectedTeachingClass.CourseClass.CourseType);
                OnPropertyChanged(nameof(AbsenceList));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Absences>(Add, param => selectedAbsence == null);
                }
                return addCommand;
            }
        }

        private void Add(Absences absence)
        {
            _absenceService.Add(absence);
            ErrorMessage = _absenceService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Absences>(Edit, param => selectedAbsence != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Absences absence)
        {
            _absenceService.Edit(absence);
            ErrorMessage = _absenceService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Absences>(Remove, param => selectedAbsence != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Absences absence)
        {
            _absenceService.Remove(absence);
            ErrorMessage = _absenceService.errorMessage;
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
            SelectedAbsence = null;
            SelectedTeachingClass = null;
            AbsenceList = _absenceService.GetAll();
            OnPropertyChanged(nameof(AbsenceList));
        }
    }
}
