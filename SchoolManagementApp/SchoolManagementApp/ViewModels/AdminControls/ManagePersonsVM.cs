using SchoolManagementApp.Commands;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminControls
{
    public class ManagePersonsVM : BaseVM
    {
        private readonly IPersonService _personService;

        public ManagePersonsVM(IPersonService personService)
        {
            this._personService = personService ?? throw new ArgumentNullException(nameof(personService));

            PersonList = personService.GetAll();
        }

        public ObservableCollection<Person> PersonList
        {
            get => _personService.PersonList;
            set => _personService.PersonList = value;
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
                    addCommand = new RelayCommands<Person>(_personService.Add, param => selectedPerson == null);
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
                    updateCommand = new RelayCommands<Person>(_personService.Edit, param => selectedPerson != null);
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
                    deleteCommand = new RelayCommands<Person>(_personService.Remove, param => selectedPerson != null);
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
