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

namespace SchoolManagementApp.ViewModels.TeacherControls
{
    public class ManageAbsencesTeacherVM : BaseVM
    {
        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly IAbsencesService _absenceService;

        private readonly ICourseService _courseService;

        private readonly ICourseClassTeacherService _courseClassTeacerService;

        private readonly ITeacherService _teacherService;

        private readonly LoggedUser loggedUser;

        private readonly Teacher teacher;

        public ManageAbsencesTeacherVM(IClassService classService, IStudentService studentService, IAbsencesService absenceService, ICourseService courseService, ICourseClassTeacherService courseClassTeacherService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._absenceService = absenceService ?? throw new ArgumentNullException(nameof(absenceService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._courseClassTeacerService = courseClassTeacherService ?? throw new ArgumentNullException(nameof(courseClassTeacherService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));


            teacher = _teacherService.GetTeacherById(this.loggedUser.User.Id);
            TeachingClassesList = _courseClassTeacerService.GetTeachingClasses(teacher.Id);

            StudentList = _studentService.GetAll();
            AbsenceList = _absenceService.GetAll();
            ClassList = _classService.GetAll();
            CourseList = _courseService.GetAll();
            Semesters = new List<int> { 1, 2 };
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

                    StudentList = new ObservableCollection<Student>(studentsFromClass);
                }
            }
        }

        #region Grade

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set
            {
                _classService.ClassList = value;
                OnPropertyChanged(nameof(ClassList));
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
                AbsenceList = _absenceService.GetStudentAbsences(selectedStudent, selectedTeachingClass.CourseClass.CourseType);
                if (selectedStudent == null)
                    CourseList = _courseService.GetAll();
                else
                    CourseList = _courseService.GetClassCourses((int)selectedStudent.ClassId);
                OnPropertyChanged(nameof(CourseList));
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
                    addCommand = new RelayCommands<Absences>(_absenceService.Add, param => selectedAbsence == null);
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
                    updateCommand = new RelayCommands<Absences>(_absenceService.Edit, param => selectedAbsence != null);
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
                    deleteCommand = new RelayCommands<Absences>(_absenceService.Remove, param => selectedAbsence != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedAbsence != null);
                }
                return clearCommand;
            }
        }
        #endregion

        private void Clear()
        {
            SelectedAbsence = null;
            SelectedTeachingClass = null;
            AbsenceList = _absenceService.GetAll();
            OnPropertyChanged(nameof(AbsenceList));
        }
    }
}
