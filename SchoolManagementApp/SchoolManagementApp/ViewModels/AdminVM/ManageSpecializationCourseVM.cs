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
    public class ManageSpecializationCourseVM : BaseVM
    {
        private readonly ICourseService courseService;

        private readonly ISpecializationService specializationService;

        private readonly ISpecializationCourseService specializationCourseService;

        public ManageSpecializationCourseVM(ICourseService courseService, ISpecializationService specializationService, ISpecializationCourseService specializationCourseService)
        {
            this.courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
            this.specializationService = specializationService ?? throw new ArgumentNullException(nameof(specializationService));
            this.specializationCourseService = specializationCourseService ?? throw new ArgumentNullException(nameof(specializationCourseService));

            CourseList = courseService.GetAll();
            SpecializationCourseList = specializationCourseService.GetAll();
            SpecializationList = specializationService.GetAll();

            foreach (CourseType course in CourseList)
            {
                foreach (Specialization specialization in SpecializationList)
                {
                    specializationCourseService.Add(new SpecializationCourse
                    {
                        Specialization = specialization,
                        SpecializationId = specialization.Id,
                        CourseType = course,
                        CourseTypeId = course.Id
                    });
                }
            }
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
            get => courseService.CourseList;
            set => courseService.CourseList = value;
        }

        public ObservableCollection<Specialization> SpecializationList
        {
            get => specializationService.SpecializationList;
            set => specializationService.SpecializationList = value;
        }

        public ObservableCollection<SpecializationCourse> SpecializationCourseList
        {
            get => specializationCourseService.SpecializationCourseList;
            set => specializationCourseService.SpecializationCourseList = value;
        }

        private SpecializationCourse selectedSpecializationCourse;
        public SpecializationCourse SelectedSpecializationCourse
        {
            get { return selectedSpecializationCourse; }
            set
            {
                selectedSpecializationCourse = value;
                OnPropertyChanged(nameof(SelectedSpecializationCourse));
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<SpecializationCourse>(Add, param => selectedSpecializationCourse == null);
                }
                return addCommand;
            }
        }

        private void Add(SpecializationCourse specializationCourse)
        {
            specializationCourseService.Add(specializationCourse);
            ErrorMessage = specializationCourseService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<SpecializationCourse>(Edit, param => selectedSpecializationCourse != null);
                }
                return updateCommand;
            }
        }

        private void Edit(SpecializationCourse specializationCourse)
        {
            specializationCourseService.Edit(specializationCourse);
            ErrorMessage = specializationCourseService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<SpecializationCourse>(Remove, param => selectedSpecializationCourse != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(SpecializationCourse specializationCourse)
        {
            specializationCourseService.Remove(specializationCourse);
            ErrorMessage = specializationCourseService.errorMessage;
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
            SelectedSpecializationCourse = null;
        }
    }
}
