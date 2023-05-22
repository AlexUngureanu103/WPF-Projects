using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageCoursesVM : BaseVM
    {
        private readonly ICourseService _courseService;

        public ManageCoursesVM(ICourseService courseService)
        {
            this._courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));

            CourseList = _courseService.GetAll();
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ObservableCollection<CourseType> CourseList
        {
            get => _courseService.CourseList;
            set => _courseService.CourseList = value;
        }

        private CourseType selectedCourse;
        public CourseType SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                selectedCourse = value;
                OnPropertyChanged(nameof(SelectedCourse));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<CourseType>(Add, param => selectedCourse == null);
                }
                return addCommand;
            }
        }

        private void Add(CourseType course)
        {
            _courseService.Add(course);
            ErrorMessage = _courseService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<CourseType>(Edit, param => selectedCourse != null);
                }
                return updateCommand;
            }
        }

        private void Edit(CourseType course)
        {
            _courseService.Edit(course);
            ErrorMessage = _courseService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<CourseType>(Remove, param => selectedCourse != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(CourseType course)
        {
            _courseService.Remove(course);
            ErrorMessage = _courseService.errorMessage;
        }

        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(Clear);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            ErrorMessage = string.Empty;
            SelectedCourse = null;
        }
    }
}
