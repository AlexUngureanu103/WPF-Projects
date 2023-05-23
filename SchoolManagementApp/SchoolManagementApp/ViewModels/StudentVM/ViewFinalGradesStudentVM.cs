using SchoolManagementApp.Commands;
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

namespace SchoolManagementApp.ViewModels.StudentVM
{
    public class ViewFinalGradesStudentVM : BaseVM
    {
        private readonly IAverageGradeService _averageGradeService;


        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        private readonly Student student;

        private readonly StudentGeneralAverage studentGeneralAverage;

        public ViewFinalGradesStudentVM(IAverageGradeService averageGradeService, ICourseService courseService, IStudentService studentService, LoggedUser loggedUser, StudentGeneralAverage studentGeneralAverage)
        {
            this._averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this.studentGeneralAverage = studentGeneralAverage ?? throw new ArgumentNullException(nameof(studentGeneralAverage));

            this.student = _studentService.GetStudentByUserId(loggedUser.User);

            CourseList = _courseService.GetClassCourses(student.Class.Id);
            StudentsAverageGradeList = _averageGradeService.GetStudentAverageGrades(student);
            Semesters = new List<int> { 1, 2 };
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

        public ObservableCollection<AverageGrade> StudentsAverageGradeList
        {
            get => _averageGradeService.AverageGrades;
            set
            {
                _averageGradeService.AverageGrades = value;
                OnPropertyChanged(nameof(StudentsAverageGradeList));
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
                    GetAllStudentAverageGrades();
                    var averageGrades = StudentsAverageGradeList.Where(c => c.ClassCourse.CourseTypeId == selectedCourse.Id);

                    StudentsAverageGradeList = new ObservableCollection<AverageGrade>(averageGrades);
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

        private int selectedSemester;
        public int SelectedSemester
        {
            get => selectedSemester;
            set
            {
                selectedSemester = value;
                OnPropertyChanged(nameof(SelectedSemester));
                if (selectedSemester != null)
                {
                    GetAllStudentAverageGrades();
                    StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.Semester == selectedSemester));
                }
            }
        }

        private ICommand allCommand;
        public ICommand AllCommand
        {
            get
            {
                if (allCommand == null)
                {
                    allCommand = new RelayCommand(GetAllStudentAverageGrades);
                }
                return allCommand;
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
                    return new RelayCommand(DisplayGeneralAverage);
                }
                return generalAverage;
            }
        }

        private void DisplayGeneralAverage()
        {
            studentGeneralAverage.DisplayGeneralAverage(student);
        }

        private void GetAllStudentAverageGrades()
        {
            StudentsAverageGradeList = _averageGradeService.GetStudentAverageGrades(student);
        }

        private void FinalGradesOnly()
        {
            StudentsAverageGradeList = new ObservableCollection<AverageGrade>(StudentsAverageGradeList.Where(c => c.Semester == 0));
        }

        private void Clear()
        {
            SelectedCourse = null;
            GetAllStudentAverageGrades();
        }
    }
}
