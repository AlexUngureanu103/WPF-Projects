using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.DataAccess.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls.ManageSpecializationVMs
{
    internal class ManageSpecializationsVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly SpecializationRepository SpecializationRepository;

        private readonly ManageSpecializationsCommands manageSpecializationsCommands;

        private ObservableCollection<Specialization> _specialization;
        public ObservableCollection<Specialization> Specializations
        {
            get { return _specialization; }
            set
            {
                _specialization = value;
                OnPropertyChanged();
            }
        }

        private Specialization selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set
            {
                selectedSpecialization = value;
                if (selectedSpecialization != null)
                {
                    CanEditSpecialization = true;
                }
                else
                {
                    CanEditSpecialization = false;
                }
                OnPropertyChanged();
            }
        }

        private bool canEditSpecialization;
        public bool CanEditSpecialization
        {
            get { return canEditSpecialization; }
            set
            {
                canEditSpecialization = value;
                OnPropertyChanged();
            }
        }

        private string addOrEditWindow;
        public string AddOrEditWindow
        {
            get { return addOrEditWindow; }
            set
            {
                addOrEditWindow = value;
                OnPropertyChanged();
            }
        }

        private string buttonContent;
        public string ButtonContent
        {
            get { return buttonContent; }
            set
            {
                buttonContent = value;
                OnPropertyChanged();
            }
        }

        private string newSpecialization;
        public string NewSpecialization
        {
            get { return newSpecialization; }
            set
            {
                newSpecialization = value;
                var rep = SpecializationRepository.GetByName(newSpecialization);

                canAddSpecialization = (rep == null && !string.IsNullOrEmpty(newSpecialization));
                OnPropertyChanged();
            }
        }

        private bool canAddSpecialization;
        public bool CanAddSpecialization
        {
            get { return canAddSpecialization; }
            set
            {
                canAddSpecialization = value;
            }
        }

        private ICommand deleteSpecialization;
        public ICommand DeleteSpecialization
        {
            get
            {
                if (deleteSpecialization == null)
                {
                    deleteSpecialization = new RelayCommand(manageSpecializationsCommands.DeleteSpecializationCommand, param => SelectedSpecialization != null);
                }
                return deleteSpecialization;
            }
        }

        private ICommand addSpecializationCommand;
        public ICommand AddSpecializationCommand
        {
            get
            {
                if (addSpecializationCommand == null)
                {
                    addSpecializationCommand = new RelayCommand(manageSpecializationsCommands.AddOrEdit, param => canAddSpecialization);
                }
                return addSpecializationCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(manageSpecializationsCommands.AddView, param => true);
                }
                return addCommand;
            }
        }

        private ICommand editCommand;
        public ICommand EditCommand
        {
            get
            {
                if (editCommand == null)
                {
                    editCommand = new RelayCommand(manageSpecializationsCommands.EditView, param => selectedSpecialization != null);
                }
                return editCommand;
            }
        }

        private ICommand sortById;
        public ICommand SortById
        {
            get
            {
                if (sortById == null)
                {
                    sortById = new RelayCommand(manageSpecializationsCommands.SortEntitiesById, param => true);
                }
                return sortById;
            }
        }

        public ManageSpecializationsVM(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            SpecializationRepository = new SpecializationRepository(_dbContext);
            manageSpecializationsCommands = new ManageSpecializationsCommands(this, SpecializationRepository);
            Specializations = new ObservableCollection<Specialization>(SpecializationRepository.GetAll());
        }
    }
}
