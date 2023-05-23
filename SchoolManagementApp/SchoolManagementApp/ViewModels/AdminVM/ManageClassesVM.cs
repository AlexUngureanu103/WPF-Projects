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
    public class ManageClassesVM : BaseVM
    {
        private readonly ISpecializationService _specializationService;

        private readonly IClassService _classService;

        private readonly ITeacherService _teacherService;

        public ManageClassesVM(IClassService classService, ISpecializationService specializationService, ITeacherService teacherService)
        {
            _classService = classService ?? throw new ArgumentNullException(nameof(classService));
            _specializationService = specializationService ?? throw new ArgumentNullException(nameof(specializationService));
            _teacherService = teacherService ?? throw new ArgumentNullException(nameof(teacherService));

            ClassList = _classService.GetAll();
            SpecializationList = _specializationService.GetAll();
            TeacherList = _teacherService.GetAll();
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

        public ObservableCollection<Class> ClassList
        {
            get => _classService.ClassList;
            set => _classService.ClassList = value;
        }

        public ObservableCollection<Specialization> SpecializationList
        {
            get => _specializationService.SpecializationList;
            set => _specializationService.SpecializationList = value;
        }

        public ObservableCollection<Teacher> TeacherList
        {
            get => _teacherService.TeacherList;
            set => _teacherService.TeacherList = value;
        }

        private Class selectedClass;
        public Class SelectedClass
        {
            get { return selectedClass; }
            set
            {
                selectedClass = value;
                OnPropertyChanged(nameof(SelectedClass));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Class>(Add, param => selectedClass == null);
                }
                return addCommand;
            }
        }

        private void Add(Class @class)
        {
            _classService.Add(@class);
            ErrorMessage = _classService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Class>(Edit, param => selectedClass != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Class @class)
        {
            _classService.Edit(@class);
            ErrorMessage = _classService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Class>(Remove, param => selectedClass != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Class @class)
        {
            _classService.Remove(@class);
            ErrorMessage = _classService.errorMessage;
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
            SelectedClass = null;
        }
    }
}
