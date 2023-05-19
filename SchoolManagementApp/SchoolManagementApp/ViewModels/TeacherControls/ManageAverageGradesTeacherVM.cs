using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Dtos;
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
    public class ManageAverageGradesTeacherVM : BaseVM
    {
        private readonly ICourseClassTeacherService _courseClassTeacerService;

        private readonly IStudentService _studentService;

        private readonly IAverageGradeService _averageGradeService;

        private readonly ITeacherService _teacherService;

        private readonly LoggedUser loggedUser;

        private readonly Teacher teacher;

        public ManageAverageGradesTeacherVM(ICourseClassTeacherService courseClassTeacerService, IStudentService studentService, IAverageGradeService averageGradeService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            _courseClassTeacerService = courseClassTeacerService ?? throw new ArgumentNullException(nameof(courseClassTeacerService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));

            teacher = _teacherService.GetTeacherById(this.loggedUser.User.Id);
            TeachingClassesList = _courseClassTeacerService.GetTeachingClasses(teacher.Id);

            //StudentList = _studentService.GetAll();
            Semesters = new List<int> { 1, 2 };
        }

        public ObservableCollection<AverageGrade> StudentsAverageGradeList
        {
            get => _averageGradeService.AverageGrades;
            set
            {
                _averageGradeService.AverageGrades = value;
                OnPropertyChanged(nameof(StudentsAverageGradeList));
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

                    StudentList = new ObservableCollection<Student>(studentsFromClass);

                    StudentsAverageGradeList = _averageGradeService.GetClassAverageGrades(selectedTeachingClass.CourseClass.Class);
                }
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

        public ObservableCollection<Student> StudentList
        {
            get => _studentService.StudentList;
            set
            {
                _studentService.StudentList = value;
                OnPropertyChanged(nameof(StudentList));
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }

        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new RelayCommands<StudentGradeAverageDto>(_averageGradeService.CalculateStudentAverageGrade);
                }

                return calculateCommand;
            }
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
            SelectedTeachingClass = null;
        }
    }
}
