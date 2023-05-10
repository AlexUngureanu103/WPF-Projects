using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class PersonService : ICollectionService<Person>
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Person> PersonList { get; set; }

        private string errorMessage;

        public PersonService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        private bool ValidatePerson(Person person)
        {
            int minAge = 10;
            if (person.DateOfBirth.CompareTo(DateTime.Now.AddYears(-minAge)) >= 0)
            {
                errorMessage = $"Person must be at least {minAge} years old";
                return false;
            }

            if (person.DateOfBirth.CompareTo(DateTime.Now.AddYears(-100)) <= 0)
            {
                errorMessage = $"Person cannot be this old";
                return false;
            }

            if (person == null || string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                errorMessage = "First name and last name cannot be empty";
                return false;
            }

            var hasNameConflicts = unitOfWork.Persons.Any(p => p.FirstName == person.FirstName && p.LastName == person.LastName);
            if (hasNameConflicts)
            {
                errorMessage = $"Person with name: {person.FirstName}  {person.LastName} already exists";
                return false;
            }

            return true;
        }

        public void Add(Person entity)
        {
            if (!ValidatePerson(entity))
                return;
            unitOfWork.Persons.Add(entity);
            PersonList.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(Person entity)
        {
            Person result = unitOfWork.Persons.GetById(entity.Id);
            if (result == null)
            {
                errorMessage = "Person not found";
                return;
            }

            if (!ValidatePerson(entity))
                return;

            unitOfWork.Persons.Update(entity);
            unitOfWork.SaveChanges();
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
            unitOfWork.SaveChanges();
        }
    }
}
