using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.TeacherVM
{
    public class ManagageGradesTeacherVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly IGradeService _gradeService;

        private readonly ICourseService _courseService;

        private readonly ICourseClassTeacherService _courseClassTeacerService;

        private readonly ITeacherService _teacherService;

        private readonly LoggedUser loggedUser;

        private readonly Teacher teacher;

        public ManagageGradesTeacherVM(IStudentService studentService, IGradeService gradeService, ICourseService courseService, ICourseClassTeacherService courseClassTeacherService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._gradeService = gradeService ?? throw new ArgumentNullException(nameof(gradeService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._courseClassTeacerService = courseClassTeacherService ?? throw new ArgumentNullException(nameof(courseClassTeacherService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));


            teacher = _teacherService.GetTeacherById(this.loggedUser.User.Id);
            TeachingClassesList = _courseClassTeacerService.GetTeachingClasses(teacher.Id);

            StudentList = _studentService.GetAll();
            GradeList = _gradeService.GetAll();
            CourseList = _courseService.GetAll();
            Semesters = new List<int> { 1, 2 };
            GradeValues = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
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
            get => _courseClassTeacerService.CourseTeacherList;
            set => _courseClassTeacerService.CourseTeacherList = value;
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

        #region Grade

        public ObservableCollection<Grade> GradeList
        {
            get => _gradeService.GradeList;
            set
            {
                _gradeService.GradeList = value;
                OnPropertyChanged(nameof(GradeList));
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

        private Grade selectedGrade;
        public Grade SelectedGrade
        {
            get { return selectedGrade; }
            set
            {
                selectedGrade = value;
                OnPropertyChanged(nameof(SelectedGrade));
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
                    GradeList = _gradeService.GetStudentGrades(selectedStudent, selectedTeachingClass.CourseClass.CourseType);
                OnPropertyChanged(nameof(CourseList));
                OnPropertyChanged(nameof(GradeList));
            }
        }

        private List<int> gradeValues;
        public List<int> GradeValues
        {
            get
            {
                return gradeValues;
            }
            set
            {
                gradeValues = value;
                OnPropertyChanged(nameof(GradeValues));
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

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Grade>(Add, param => selectedGrade == null);
                }
                return addCommand;
            }
        }

        private void Add(Grade grade)
        {
            _gradeService.Add(grade);
            ErrorMessage = _gradeService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Grade>(Edit, param => selectedGrade != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Grade grade)
        {
            _gradeService.Edit(grade);
            ErrorMessage = _gradeService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Grade>(Remove, param => selectedGrade != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Grade grade)
        {
            _gradeService.Remove(grade);
            ErrorMessage = _gradeService.errorMessage;
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
        #endregion

        private void Clear()
        {
            ErrorMessage = string.Empty;
            SelectedGrade = null;
            SelectedTeachingClass = null;
            GradeList = _gradeService.GetAll();
            OnPropertyChanged(nameof(GradeList));
        }
    }
}
