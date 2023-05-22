using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ViewCorrigentsClassMasterVM : BaseVM
    {
        private readonly IAverageGradeService _averageGradeService;

        private readonly IClassService _classService;

        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        private readonly ITeacherService _teacherService;


        private readonly Teacher classMaster;

        public readonly Class ownClass;

        public ViewCorrigentsClassMasterVM(IAverageGradeService averageGradeService, IClassService classService, ICourseService courseService, ITeacherService teacherService, IStudentService studentService, LoggedUser loggedUser)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));

            classMaster = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(classMaster);

            CourseList = _courseService.GetClassCourses(ownClass.Id);
            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            GetStudentsAverageGrades();
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
                GetStudentsAverageGrades();
                if (selectedCourse != null)
                {
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
                GetStudentsAverageGrades();
                if (selectedCourse != null)
                {
                    StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.ClassCourse.CourseTypeId == SelectedCourse.Id));
                }
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
            SelectedCourse = null;
            SelectedStudent = null;
            GetStudentsAverageGrades();
        }

        private void GetStudentsAverageGrades()
        {
            StudentsAverageGradeList = new ObservableCollection<AverageGrade>(_averageGradeService.GetClassAverageGrades(ownClass).Where(c => c.Average < 5));
        }
    }
}
