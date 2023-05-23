using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.ApplicationLayer;
using SchoolManagementApp.Services.BusinessLayer.Commands;
using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ViewRepeatersClassMasterVM : BaseVM
    {
        private readonly IAverageGradeService _averageGradeService;

        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly ITeacherService _teacherService;

        private readonly Teacher classMaster;

        public readonly Class ownClass;

        private readonly RepeaterStudents repeaterStudents;

        public ViewRepeatersClassMasterVM(IAverageGradeService averageGradeService, IClassService classService, ITeacherService teacherService, IStudentService studentService, LoggedUser loggedUser, RepeaterStudents repeaterStudents)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            this.repeaterStudents = repeaterStudents ?? throw new ArgumentNullException(nameof(repeaterStudents));

            classMaster = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(classMaster);

            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            GetRepeaterStudents();
        }

        private ObservableCollection<RepeaterStudentDto> studentRepeaterList;
        public ObservableCollection<RepeaterStudentDto> StudentRepeaterList
        {
            get => studentRepeaterList;
            set
            {
                studentRepeaterList = value;
                OnPropertyChanged(nameof(StudentRepeaterList));
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

        private void GetRepeaterStudents()
        {
            StudentRepeaterList = repeaterStudents.GetRepeaterStudents(StudentList);
        }
    }
}
