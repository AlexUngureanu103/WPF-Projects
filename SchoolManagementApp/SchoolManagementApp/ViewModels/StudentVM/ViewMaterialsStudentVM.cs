using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using SchoolManagementApp.Services.Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.StudentVM
{
    public class ViewMaterialsStudentVM : BaseVM
    {
        private readonly IStudentService _studentService;

        private readonly ICourseService _courseService;

        private readonly ICourseClassTeacherService _courseClassTeacherService;

        private readonly ITeachingMaterialsService _teachingMaterialsService;

        private readonly Student student;

        public ViewMaterialsStudentVM(IStudentService studentService, ICourseService courseService, ICourseClassTeacherService courseClassTeacherService, ITeachingMaterialsService teachingMaterialsService, LoggedUser loggedUser)
        {
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
            _courseService = courseService ?? throw new ArgumentException(nameof(courseService));
            _courseClassTeacherService = courseClassTeacherService ?? throw new ArgumentException(nameof(courseClassTeacherService));
            _teachingMaterialsService = teachingMaterialsService ?? throw new ArgumentException(nameof(teachingMaterialsService));

            this.student = _studentService.GetStudentByUserId(loggedUser.User);
            Semesters = new List<int> { 1, 2 };
            CourseList = _courseService.GetClassCourses(student.Class.Id);
        }

        public ObservableCollection<TeachingMaterial> TeachingMaterialsList
        {
            get => _teachingMaterialsService.TeachingMaterialsList;
            set
            {
                _teachingMaterialsService.TeachingMaterialsList = value;
                OnPropertyChanged(nameof(TeachingMaterialsList));
            }
        }

        private TeachingMaterial selectedTeachingMaterial;
        public TeachingMaterial SelectedTeachingMaterial
        {
            get => selectedTeachingMaterial;
            set
            {
                selectedTeachingMaterial = value;
                OnPropertyChanged(nameof(SelectedTeachingMaterial));
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
                    var teachingMaterials = _teachingMaterialsService.GetClassTeachingMaterials(student.Class);

                    TeachingMaterialsList = new ObservableCollection<TeachingMaterial>(teachingMaterials.Where(x => x.CourseClass.CourseTypeId == selectedCourse.Id));
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
                    var teachingMaterials = _teachingMaterialsService.GetClassTeachingMaterials(student.Class).Where(c => c.Semester == selectedSemester);

                    TeachingMaterialsList = new ObservableCollection<TeachingMaterial>(teachingMaterials);
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
                    allCommand = new RelayCommand(AllAbsences);
                }
                return allCommand;
            }
        }

        public void AllAbsences()
        {
            TeachingMaterialsList = _teachingMaterialsService.GetClassTeachingMaterials(student.Class);
        }
    }
}
