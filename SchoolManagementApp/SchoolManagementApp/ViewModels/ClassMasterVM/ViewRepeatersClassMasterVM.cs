using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.Application;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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

        public ViewRepeatersClassMasterVM(IAverageGradeService averageGradeService, IClassService classService, ITeacherService teacherService, IStudentService studentService, LoggedUser loggedUser)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));

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
            StudentRepeaterList = new ObservableCollection<RepeaterStudentDto>();

            foreach (Student student in StudentList)
            {
                var corrigentCourses = _averageGradeService.GetStudentAverageGrades(student)
                    .Where(c => c.Semester == 0 && c.Average < 5).ToList()
                    .Select(c => c.ClassCourse.CourseType)
                    .ToList();
                var reapeater = Mapper.CreateRepeaterStudentDto(student, corrigentCourses);
                if (reapeater != null)
                {
                    StudentRepeaterList.Add(reapeater);
                }
            }
        }
    }
}
