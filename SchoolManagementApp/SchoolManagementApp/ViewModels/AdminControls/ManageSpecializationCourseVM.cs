using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    public class ManageSpecializationCourseVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly CourseService courseService;

        private readonly SpecializationService specializationService;

        private readonly SpecializationCourseService specializationCourseService;

        private readonly UnitOfWork unitOfWork;

        public ManageSpecializationCourseVM(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            unitOfWork = new UnitOfWork(_dbContext);
            courseService = new CourseService(unitOfWork);
            specializationCourseService = new SpecializationCourseService(unitOfWork);
            specializationService = new SpecializationService(unitOfWork);

            CourseList = courseService.GetAll();
            SpecializationCourseList = specializationCourseService.GetAll();
            SpecializationList = specializationService.GetAll();
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
