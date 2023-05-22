using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.Application;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ViewExmatriculationSituationClassMasterVM : BaseVM
    {
        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly IAbsencesService _absenceService;

        private readonly ITeacherService _teacherService;

        private readonly Teacher classMaster;

        public readonly Class ownClass;

        public ViewExmatriculationSituationClassMasterVM(IClassService classService, IStudentService studentService, IAbsencesService absenceService, ITeacherService teacherService, LoggedUser loggedUser)
        {
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this._absenceService = absenceService ?? throw new ArgumentNullException(nameof(absenceService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            if (loggedUser == null)
                throw new ArgumentNullException(nameof(loggedUser));

            classMaster = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(classMaster);

            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            AbsenceList = new ObservableCollection<Absences>(_absenceService.GetAll().Where(x => x.Student.ClassId == ownClass.Id && !x.IsMotivated));
            GetStudentAbsences();
        }

        private ObservableCollection<Absences> absenceList;
        public ObservableCollection<Absences> AbsenceList
        {
            get => absenceList;
            set
            {
                absenceList = value;
                OnPropertyChanged(nameof(AbsenceList));
            }
        }

        private ObservableCollection<StudentAbsenceDto> studentAbsencesList;
        public ObservableCollection<StudentAbsenceDto> StudentAbsencesList
        {
            get => studentAbsencesList;
            set
            {
                studentAbsencesList = value;
                OnPropertyChanged(nameof(StudentAbsencesList));
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

        private ICommand exmatriculationSituationCommand;
        public ICommand ExmatriculationSituationCommand
        {
            get
            {
                if (exmatriculationSituationCommand == null)
                {
                    exmatriculationSituationCommand = new RelayCommand(ExmatriculationSituationOnly);
                }
                return exmatriculationSituationCommand;
            }
        }
        private ICommand allComand;
        public ICommand AllCommand
        {
            get
            {
                if (allComand == null)
                {
                    allComand = new RelayCommand(GetStudentAbsences);
                }
                return allComand;
            }
        }

        private void ExmatriculationSituationOnly()
        {
            StudentAbsencesList = new ObservableCollection<StudentAbsenceDto>(studentAbsencesList.Where(c => c.CanBeExmatriculated));
        }

        private void GetStudentAbsences()
        {
            var studentAbsences = new ObservableCollection<StudentAbsenceDto>();
            foreach (var student in StudentList)
            {
                int abcensesCount = absenceList.Count(c => c.StudentId == student.Id);
                studentAbsences.Add(Mapper.CreateStudentAbsenceDto(student, abcensesCount));
            }
            StudentAbsencesList = studentAbsences;
        }
    }
}
