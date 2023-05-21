using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class PersonService : IPersonService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Person> PersonList { get; set; }

        private string errorMessage;

        private readonly log4net.ILog log;

        public PersonService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        private bool ValidatePerson(Person person)
        {
            int minAge = 10;
            if (person.DateOfBirth.CompareTo(DateTime.Now.AddYears(-minAge)) >= 0)
            {
                errorMessage = $"Person must be at least {minAge} years old";
                log.Error(errorMessage);
                return false;
            }

            if (person.DateOfBirth.CompareTo(DateTime.Now.AddYears(-100)) <= 0)
            {
                errorMessage = $"Person cannot be this old";
                log.Error(errorMessage);
                return false;
            }

            if (person == null || string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                errorMessage = "First name and last name cannot be empty";
                log.Error(errorMessage);
                return false;
            }

            //var hasNameConflicts = unitOfWork.Persons.Any(p => p.FirstName == person.FirstName && p.LastName == person.LastName);
            //if (hasNameConflicts)
            //{
            //    errorMessage = $"Person with name: {person.FirstName}  {person.LastName} already exists";
            //    return false;
            //}

            return true;
        }

        public void Add(Person entity)
        {
            if (!ValidatePerson(entity))
                return;
            unitOfWork.Persons.Add(entity);
            PersonList.Add(entity);

            //unitOfWork.SaveChanges();
            log.Info($"Person with name: {entity.FirstName} {entity.LastName} added");
        }

        public void Edit(Person entity)
        {
            Person resultFromDb = unitOfWork.Persons.GetById(entity.Id);
            if (resultFromDb == null)
            {
                errorMessage = "Person not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidatePerson(entity))
                return;

            unitOfWork.Persons.Update(entity);
            ////unitOfWork.Persons.Update(entity);
            //resultFromDb.FirstName = entity.FirstName;
            //resultFromDb.LastName = entity.LastName;
            //resultFromDb.DateOfBirth = entity.DateOfBirth;
            //resultFromDb.Address = entity.Address;

            //unitOfWork.SaveChanges();
            log.Info($"Person with name: {entity.FirstName} {entity.LastName} edited");
        }

        public ObservableCollection<Person> GetAll()
        {
            return new ObservableCollection<Person>(unitOfWork.Persons.GetAll());
        }

        public void Remove(Person entity)
        {
            if (entity == null)
            {
                errorMessage = "Person cannot be null";
            }

            unitOfWork.Persons.Remove(entity);
            PersonList.Remove(entity);
            //unitOfWork.SaveChanges();
            log.Info($"Person with name: {entity.FirstName} {entity.LastName} removed");
        }
    }
}