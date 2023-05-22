using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.Application;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.StudentVM
{
    public class ViewAbsencesStudentVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly IClassService _classService;

        private readonly IAbsencesService _absencesService;

        private readonly ICourseService _courseService;

        private readonly Student student;

        public ViewAbsencesStudentVM(IStudentService studentService, IClassService classService, IAbsencesService absencesService, ICourseService courseService, LoggedUser loggedUser)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _absencesService = absencesService ?? throw new ArgumentNullException(nameof(absencesService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));


            this.student = studentService.GetStudentByUserId(loggedUser.User);

            AbsenceList = _absencesService.GetStudentAbsences(student);
            CourseList = _courseService.GetClassCourses(student.Class.Id);
        }

        public ObservableCollection<Absences> AbsenceList
        {
            get => _absencesService.AbsenceList;
            set
            {
                _absencesService.AbsenceList = value;
                OnPropertyChanged(nameof(AbsenceList));
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
                    var absences = _absencesService.GetStudentAbsences(student);

                    AbsenceList = new ObservableCollection<Absences>(absences.Where(x => x.CourseType.Id == selectedCourse.Id));
                }
            }
        }

        private ICommand onlyUnMotivatedCommand;
        public ICommand OnlyUnMotivatedCommand
        {
            get
            {
                if (onlyUnMotivatedCommand == null)
                {
                    onlyUnMotivatedCommand = new RelayCommand(OnlyUnmotivated);
                }
                return onlyUnMotivatedCommand;
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

        private void OnlyUnmotivated()
        {
            AbsenceList = new ObservableCollection<Absences>(AbsenceList.Where(c => !c.IsMotivated));
        }

        public void AllAbsences()
        {
            AbsenceList = _absencesService.GetStudentAbsences(student);
        }
    }
}
