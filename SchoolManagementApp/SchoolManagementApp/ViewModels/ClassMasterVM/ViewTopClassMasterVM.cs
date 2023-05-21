using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services;
using System;
using System.Collections.ObjectModel;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.ClassMasterVM
{
    public class ViewTopClassMasterVM : BaseVM
    {
        private readonly IAverageGradeService _averageGradeService;

        private readonly IClassService _classService;

        private readonly IStudentService _studentService;

        private readonly ITeacherService _teacherService;

        private readonly ICourseService _courseService;

        private readonly Teacher classMaster;

        public readonly Class ownClass;

        public ViewTopClassMasterVM(IAverageGradeService averageGradeService, IClassService classService, ITeacherService teacherService, ICourseService courseService, IStudentService studentService, LoggedUser loggedUser)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));

            classMaster = _teacherService.GetTeacherById(loggedUser.User.Id);
            ownClass = _classService.GetClassByClassMasterId(classMaster);

            CourseList = _courseService.GetClassCourses(ownClass.Id);
            StudentList = _studentService.GetStudentsByClassId(ownClass.Id);
            GetStudentsTop();
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set => _courseService.CourseList = value;
        }

        private ObservableCollection<StudentTopDto> studentTopList;
        public ObservableCollection<StudentTopDto> StudentTopList
        {
            get => studentTopList;
            set
            {
                studentTopList = value;
                OnPropertyChanged(nameof(StudentTopList));
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

        private void GetStudentsTop()
        {
            StudentTopList = Mapper.CreateStudentsTop(StudentList, _averageGradeService.GetClassAverageGrades(ownClass), CourseList.Count);
        }
    }
}
