﻿using SchoolManagementApp.Commands;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using To_Do_List_Management_App.ViewModels;

namespace SchoolManagementApp.ViewModels.AdminVM
{
    public class ManagePersonsVM : BaseVM
    {
        private readonly IPersonService _personService;

        public ManagePersonsVM(IPersonService personService)
        {
            this._personService = personService ?? throw new ArgumentNullException(nameof(personService));

            PersonList = personService.GetAll();
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
                    addCommand = new RelayCommands<Person>(Add, param => selectedPerson == null);
                }
                return addCommand;
            }
        }

        private void Add(Person person)
        {
            _personService.Add(person);
            ErrorMessage = _personService.errorMessage;
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                {
                    updateCommand = new RelayCommands<Person>(Edit, param => selectedPerson != null);
                }
                return updateCommand;
            }
        }

        private void Edit(Person person)
        {
            _personService.Edit(person);
            ErrorMessage = _personService.errorMessage;
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (deleteCommand == null)
                {
                    deleteCommand = new RelayCommands<Person>(Remove, param => selectedPerson != null);
                }
                return deleteCommand;
            }
        }

        private void Remove(Person person)
        {
            _personService.Remove(person);
            ErrorMessage = _personService.errorMessage;
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
            SelectedPerson = null;
        }
    }
}
