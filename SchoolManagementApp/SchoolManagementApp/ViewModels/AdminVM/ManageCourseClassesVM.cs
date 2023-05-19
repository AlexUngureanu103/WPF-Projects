using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageCourseClassesVM : BaseVM
    {
        private readonly ICourseService _courseService;

        private readonly IClassService _classService;

        private readonly ICourseClassService _courseClassService;

        public ManageCourseClassesVM(ICourseClassService courseClassService, ICourseService courseService, IClassService classService)
        {
            this._courseClassService = courseClassService ?? throw new ArgumentNullException(nameof(courseClassService));
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));

            ClassList = _classService.GetAll();
            CourseClassList = _courseClassService.GetAll();
            CourseList = _courseService.GetAll();

            foreach (var @class in ClassList)
            {
                foreach (var course in CourseList)
                {
                    _courseClassService.Add(new CourseClass
                    {
                        Class = @class,
                        ClassId = @class.Id,
                        CourseType = course,
                        CourseTypeId = course.Id
                    });
                }
            }

        }

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set => _classService.ClassList = value;
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set => _courseService.CourseList = value;
        }

        public ObservableCollection<CourseClass> CourseClassList
        {
            get => _courseClassService.CourseClassList;
            set => _courseClassService.CourseClassList = value;
        }

        private CourseClass selectedCourseClass;
        public CourseClass SelectedCourseClass
        {
            get { return selectedCourseClass; }
            set
            {
                selectedCourseClass = value;
                OnPropertyChanged(nameof(SelectedCourseClass));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<CourseClass>(_courseClassService.Add, param => selectedCourseClass == null);
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
                    updateCommand = new RelayCommands<CourseClass>(_courseClassService.Edit, param => selectedCourseClass != null);
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
                    deleteCommand = new RelayCommands<CourseClass>(_courseClassService.Remove, param => selectedCourseClass != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedCourseClass != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedCourseClass = null;
        }
    }
}
