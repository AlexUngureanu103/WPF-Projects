using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using SchoolManagementApp.Services.BusinessLayer.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ManageFinalGradesClassMasterVM : BaseVM
    {
        private readonly IAverageGradeService _averageGradeService;

        private readonly IClassService _classService;

        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        private readonly ITeacherService _teacherService;

        private readonly ICourseClassService _courseClassService;

        private readonly Teacher classMaster;

        public readonly Class ownClass;

        private readonly StudentGeneralAverage studentGeneralAverage;

        public ManageFinalGradesClassMasterVM(IAverageGradeService averageGradeService, IClassService classService, ICourseService courseService, ITeacherService teacherService, ICourseClassService courseClassService, IStudentService studentService, LoggedUser loggedUser, StudentGeneralAverage studentGeneralAverage)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _courseClassService = courseClassService ?? throw new ArgumentNullException(nameof(courseClassService));
            this.studentGeneralAverage = studentGeneralAverage ?? throw new ArgumentNullException(nameof(studentGeneralAverage));

            classMaster = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(classMaster);

            CourseClasseList = new ObservableCollection<CourseClass>(_courseClassService.GetAll().Where(c => c.ClassId == ownClass.Id && c.HasCourse));
            CourseList = _courseService.GetClassCourses(ownClass.Id);

            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            GetClassAverageGrades();
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

        public ObservableCollection<CourseClass> CourseClasseList
        {
            get => _courseClassService.CourseClassList;
            set
            {
                _courseClassService.CourseClassList = value;
                OnPropertyChanged(nameof(CourseClasseList));
            }
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
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
                if (selectedStudent != null)
                {
                    GetClassAverageGrades();
                    StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.StudentId == selectedStudent.Id));
                }
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

        private CourseType selectedCourse;
        public CourseType SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
                if (selectedCourse != null)
                {
                    GetClassAverageGrades();
                    StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.ClassCourse.CourseTypeId == selectedCourse.Id));
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

        private ICommand calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                if (calculateCommand == null)
                {
                    calculateCommand = new RelayCommands<StudentFinalGradeDto>(CalculateStudentFinalGrade);
                }

                return calculateCommand;
            }
        }

        private void CalculateStudentFinalGrade(StudentFinalGradeDto studentFinalGradeDto)
        {
            _averageGradeService.CalculateStudentFinalGrade(studentFinalGradeDto);
            ErrorMessage = _averageGradeService.errorMessage;
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

        private ICommand finalGradesCommand;
        public ICommand FinalGradesCommand
        {
            get
            {
                if (finalGradesCommand == null)
                {
                    finalGradesCommand = new RelayCommand(FinalGradesOnly);
                }
                return finalGradesCommand;
            }
        }

        private ICommand generalAverage;
        public ICommand GeneralAverage
        {
            get
            {
                if (generalAverage == null)
                {
                    return new RelayCommand(DisplayGeneralAverage, param => selectedStudent != null);
                }
                return generalAverage;
            }
        }

        private void DisplayGeneralAverage()
        {
            studentGeneralAverage.DisplayGeneralAverage(selectedStudent);
        }

        private void FinalGradesOnly()
        {
            StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.Semester == 0));
        }

        private void GetClassAverageGrades()
        {
            StudentsAverageGradeList = _averageGradeService.GetClassAverageGrades(ownClass);
        }

        private void Clear()
        {
            GetClassAverageGrades();
            ErrorMessage = string.Empty;
            SelectedCourse = null;
            SelectedStudent = null;
        }
    }
}
