using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    internal class ManagePersonsVM : BaseVM
    {
        private readonly SchoolManagementDbContext _dbContext;

        private readonly PersonService personService;

        private readonly UnitOfWork unitOfWork;

        public ManagePersonsVM(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            unitOfWork = new UnitOfWork(_dbContext);
            personService = new PersonService(unitOfWork);

            PersonList = personService.GetAll();
        }

        public ObservableCollection<Person> PersonList
        {
            get => personService.PersonList;
            set => personService.PersonList = value;
        }

        private Person selectedPerson;
        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommands<Person>(personService.Add, param => selectedPerson == null);
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
                    updateCommand = new RelayCommands<Person>(personService.Edit, param => selectedPerson != null);
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
                    deleteCommand = new RelayCommands<Person>(personService.Remove, param => selectedPerson != null);
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
                    clearCommand = new RelayCommand(Clear, param => selectedPerson != null);
                }
                return clearCommand;
            }
        }

        private void Clear()
        {
            SelectedPerson = null;
        }
    }
}
