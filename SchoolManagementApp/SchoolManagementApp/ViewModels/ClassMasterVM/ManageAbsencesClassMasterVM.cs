using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ManageAbsencesClassMasterVM : BaseVM
    {
        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly IAbsencesService _absenceService;

        private readonly ICourseService _courseService;

        private readonly ITeacherService _teacherService;

        private readonly LoggedUser loggedUser;

        private readonly Teacher classMaster;

        public readonly Class ownClass;

        public ManageAbsencesClassMasterVM(IClassService classService, IStudentService studentService, IAbsencesService absenceService, ICourseService courseService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._absenceService = absenceService ?? throw new ArgumentNullException(nameof(absenceService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this.loggedUser = loggedUser ?? throw new ArgumentNullException(nameof(loggedUser));

            classMaster = _teacherService.GetTeacherById(this.loggedUser.User.Id);

            ownClass = _classService.GetClassByClassMasterId(classMaster);

            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            AbsenceList = new ObservableCollection<Absences>(_absenceService.GetAll().Where(x => x.Student.ClassId == ownClass.Id));
            CourseList = _courseService.GetClassCourses(ownClass.Id);
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

        private CourseType selectedCourse;
        public CourseType SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
                if (selectedStudent != null)
                    AbsenceList = _absenceService.GetStudentAbsences(selectedStudent, SelectedCourse);
                else
                {
                    AbsenceList = new ObservableCollection<Absences>(_absenceService.GetAll().Where(x => x.Student.ClassId == ownClass.Id));
                }
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
                if (selectedCourse != null)
                    AbsenceList = _absenceService.GetStudentAbsences(selectedStudent, SelectedCourse);
                else
                {
                    AbsenceList = new ObservableCollection<Absences>(_absenceService.GetAll().Where(x => x.Student.ClassId == ownClass.Id));
                }
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Absences>(_absenceService.MotivateAbsence, param => selectedAbsence != null);
                }
                return updateCommand;
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

        private void OnlyUnmotivated()
        {
            AbsenceList = new ObservableCollection<Absences>(AbsenceList.Where(c => !c.IsMotivated));
        }

        private void Clear()
        {
            SelectedAbsence = null;
            SelectedCourse = null;
            SelectedStudent = null;
            AbsenceList = new ObservableCollection<Absences>(_absenceService.GetAll().Where(x => x.Student.ClassId == ownClass.Id));
        }
    }
}
