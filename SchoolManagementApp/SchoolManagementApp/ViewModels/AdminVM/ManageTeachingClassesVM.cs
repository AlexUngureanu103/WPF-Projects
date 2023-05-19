using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageTeachingClassesVM : BaseVM
    {
        private readonly ICourseClassTeacherService _courseClassTeacherService;

        private readonly ICourseClassService _courseClassService;

        private readonly ITeacherService _teacherService;

        private readonly ICourseService _courseService;

        private readonly IClassService _classService;

        public ManageTeachingClassesVM(ICourseClassService courseClassService, ICourseClassTeacherService courseClassTeacherService, ITeacherService teacherService, ICourseService courseService, IClassService classService)
        {
            this._courseClassService = courseClassService ?? throw new ArgumentNullException(nameof(courseClassService));
            this._courseClassTeacherService = courseClassTeacherService ?? throw new ArgumentNullException(nameof(courseClassTeacherService));
            this._teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));

            CourseClassList = new ObservableCollection<CourseClass>(_courseClassService.GetAll().Where(c => c.HasCourse == true));
            TeacherList = _teacherService.GetAll();
            CourseClassTeacherList = _courseClassTeacherService.GetAll();
        }

        public ObservableCollection<CourseType> CourseList
        {
            get { return _courseService.CourseList; }
            set
            {
                _courseService.CourseList = value;
                OnPropertyChanged(nameof(CourseList));
            }
        }

        private CourseType selectedCourseType;
        public CourseType SelectedCourseType
        {
            get => selectedCourseType;
            set
            {
                selectedCourseType = value;
                OnPropertyChanged(nameof(SelectedCourseType));
                // change class list
            }
        }

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set
            {
                _classService.ClassList = value;
                OnPropertyChanged(nameof(ClassList));
            }
        }

        private Class selectedClass;
        public Class SelectedClass
        {
            get => selectedClass;
            set
            {
                selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
                //change course lists
            }
        }

        public ObservableCollection<CourseClassTeacher> CourseClassTeacherList
        {
            get => _courseClassTeacherService.CourseTeacherList;
            set => _courseClassTeacherService.CourseTeacherList = value;
        }

        public ObservableCollection<CourseClass> CourseClassList
        {
            get => _courseClassService.CourseClassList;
            set => _courseClassService.CourseClassList = value;
        }

        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherService.TeacherList;
            set => _teacherService.TeacherList = value;
        }

        private CourseClassTeacher selectedCourseClassTeacher;
        public CourseClassTeacher SelectedCourseClassTeacher
        {
            get { return selectedCourseClassTeacher; }
            set
            {
                selectedCourseClassTeacher = value;
                OnPropertyChanged(nameof(SelectedCourseClassTeacher));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<CourseClassTeacher>(_courseClassTeacherService.Add, param => selectedCourseClassTeacher == null);
                }
                return addCommand;
            }
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<CourseClassTeacher>(_courseClassTeacherService.Edit, param => selectedCourseClassTeacher != null);
                }
                return updateCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<CourseClassTeacher>(_courseClassTeacherService.Remove, param => selectedCourseClassTeacher != null);
                }
                return deleteCommand;
            }
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear, param => selectedCourseClassTeacher != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedCourseClassTeacher = null;
        }
    }
}
