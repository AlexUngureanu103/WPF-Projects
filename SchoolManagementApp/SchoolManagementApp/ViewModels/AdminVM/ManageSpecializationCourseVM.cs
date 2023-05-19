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
                    addCommand = new RelayCommands<SpecializationCourse>(specializationCourseService.Add, param => selectedSpecializationCourse == null);
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
                    updateCommand = new RelayCommands<SpecializationCourse>(specializationCourseService.Edit, param => selectedSpecializationCourse != null);
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
                    deleteCommand = new RelayCommands<SpecializationCourse>(specializationCourseService.Remove, param => selectedSpecializationCourse != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedSpecializationCourse != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedSpecializationCourse = null;
        }
    }
}
