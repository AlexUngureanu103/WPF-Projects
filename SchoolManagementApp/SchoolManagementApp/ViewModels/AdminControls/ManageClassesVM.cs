using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    public class ManageClassesVM : BaseVM
    {
        public readonly ISpecializationService _specializationService;

        private readonly IClassService _classService;

        public ManageClassesVM(IClassService classService, ISpecializationService specializationService)
        {
            this._classService = classService ?? throw new ArgumentNullException(nameof(classService));
            this._specializationService = specializationService ?? throw new ArgumentNullException(nameof(specializationService));

            ClassList = classService.GetAll();
            SpecializationList = specializationService.GetAll();
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
                    addCommand = new RelayCommands<Class>(_classService.Add, param => selectedClass == null);
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
                    updateCommand = new RelayCommands<Class>(_classService.Edit, param => selectedClass != null);
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
                    deleteCommand = new RelayCommands<Class>(_classService.Remove, param => selectedClass != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedClass != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedClass = null;
        }
    }
}
