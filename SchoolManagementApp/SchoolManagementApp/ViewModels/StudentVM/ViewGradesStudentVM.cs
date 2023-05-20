using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.StudentVM
{
    public class ViewGradesStudentVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly IClassService _classService;

        private readonly IGradeService _gradeService;

        private readonly ICourseService _courseService;

        private readonly Student student;

        public ViewGradesStudentVM(IStudentService studentService, IClassService classService, IGradeService gradeService, ICourseService courseService, LoggedUser loggedUser)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _gradeService = gradeService ?? throw new ArgumentNullException(nameof(gradeService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));


            this.student = studentService.GetStudentByUserId(loggedUser.User);

            GradeList = _gradeService.GetStudentGrades(student);
            CourseList = _courseService.GetClassCourses(student.Class.Id);
            Semesters = new List<int> { 1, 2 };
        }


        public ObservableCollection<Grade> GradeList
        {
            get => _gradeService.GradeList;
            set
            {
                _gradeService.GradeList = value;
                OnPropertyChanged(nameof(GradeList));
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
                    var grades = _gradeService.GetStudentGrades(student);

                    GradeList = new ObservableCollection<Grade>(grades.Where(x => x.CourseTypeId == selectedCourse.Id));
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
                    var grades = _gradeService.GetStudentGrades(student).Where(c => c.Semester == selectedSemester);

                    GradeList = new ObservableCollection<Grade>(grades);
                }
            }
        }

        private ICommand thesisCommand;
        public ICommand ThesisCommand
        {
            get
            {
                if (thesisCommand == null)
                {
                    thesisCommand = new RelayCommand(ThesisOnly);
                }
                return thesisCommand;
            }
        }

        private ICommand allCommand;
        public ICommand AllCommand
        {
            get
            {
                if (allCommand == null)
                {
                    allCommand = new RelayCommand(AllAbsences);
                }
                return allCommand;
            }
        }

        private void ThesisOnly()
        {
            GradeList = new ObservableCollection<Grade>(GradeList.Where(c => c.IsThesis));
        }

        public void AllAbsences()
        {
            GradeList = _gradeService.GetStudentGrades(student);
        }
    }
}
