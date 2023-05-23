using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManageSpecializationsVM : BaseVM
    {
        private readonly ISpecializationService _specializationService;

        public ManageSpecializationsVM(ISpecializationService specializationService)
        {
            this._specializationService = specializationService ?? throw new ArgumentNullException(nameof(specializationService));

            SpecializationList = _specializationService.GetAll();
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

        public ObservableCollection<Specialization> SpecializationList
        {
            get => _specializationService.SpecializationList;
            set => _specializationService.SpecializationList = value;
        }

        private Specialization selectedSpecialization;
        public Specialization SelectedSpecialization
        {
            get { return selectedSpecialization; }
            set
            {
                selectedSpecialization = value;
                OnPropertyChanged(nameof(SelectedSpecialization));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Specialization>(Add, param => selectedSpecialization == null);
                }
                return addCommand;
            }
        }

        private void Add(Specialization specialization)
        {
            _specializationService.Add(specialization);
            ErrorMessage = _specializationService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Specialization>(Edit, param => selectedSpecialization != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Specialization specialization)
        {
            _specializationService.Edit(specialization);
            ErrorMessage = _specializationService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Specialization>(Remove, param => selectedSpecialization != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Specialization specialization)
        {
            _specializationService.Remove(specialization);
            ErrorMessage = _specializationService.errorMessage;
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
            SelectedSpecialization = null;
        }
    }

}

