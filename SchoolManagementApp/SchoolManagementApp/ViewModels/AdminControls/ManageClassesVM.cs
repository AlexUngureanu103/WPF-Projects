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
    internal class ManageClassesVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        public readonly SpecializationService specializationService;

        private readonly ClassService classService;

        public ManageClassesVM(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            var unitOfWork = new UnitOfWork(dbContext);
            specializationService = new SpecializationService(unitOfWork);
            classService = new ClassService(unitOfWork);

            ClassList = classService.GetAll();
            SpecializationList = specializationService.GetAll();
        }

        public ObservableCollection<Class> ClassList
        {
            get => classService.ClassList;
            set => classService.ClassList = value;
        }

        public ObservableCollection<Specialization> SpecializationList
        {
            get => specializationService.SpecializationList;
            set => specializationService.SpecializationList = value;
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
                    addCommand = new RelayCommands<Class>(classService.Add, param => selectedClass == null);
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
                    updateCommand = new RelayCommands<Class>(classService.Edit, param => selectedClass != null);
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
                    deleteCommand = new RelayCommands<Class>(classService.Remove, param => selectedClass != null);
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
            selectedClass = null;
        }
    }
}
