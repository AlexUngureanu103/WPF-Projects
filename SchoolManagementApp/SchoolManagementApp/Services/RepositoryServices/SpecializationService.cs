using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    public class SpecializationService : ISpecializationService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Specialization> SpecializationList { get; set; }

        private string errorMessage;

        public SpecializationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<Specialization> GetAll()
        {
            return new ObservableCollection<Specialization>(unitOfWork.Specializations.GetAll());
        }

        public Specialization GetById(int id)
        {
            return unitOfWork.Specializations.GetById(id);
        }

        private bool ValidateSpecialization(Specialization specialization)
        {
            if (specialization == null)
            {
                errorMessage = "Specialization cannot be null";
                return false;
            }

            if (string.IsNullOrEmpty(specialization.Name))
            {
                errorMessage = "Name cannot be empty";
                return false;
            }
            var hasNameConflicts = unitOfWork.Specializations.Any(c => c.Name == specialization.Name);
            if (hasNameConflicts)
            {
                errorMessage = $"SPecialization with name {specialization.Name} already exists";
                return false;
            }
            return true;
        }

        public void Add(Specialization specialization)
        {
            if (!ValidateSpecialization(specialization))
                return;

            unitOfWork.Specializations.Add(specialization);
            SpecializationList.Add(specialization);
            unitOfWork.SaveChanges();
        }

        public void Edit(Specialization specialization)
        {
            Specialization specializationFromDb = unitOfWork.Specializations.GetById(specialization.Id);

            if (specializationFromDb == null)
            {
                errorMessage = "Specialization not found";
                return;
            }

            if (!ValidateSpecialization(specialization))
                return;

            //unitOfWork.Specializations.Update(specialization);
            specializationFromDb.Name = specialization.Name;

            unitOfWork.SaveChanges();
        }

        public void Remove(Specialization specialization)
        {
            if (specialization == null)
            {
                errorMessage = "Specialization cannot be null";
                return;
            }

            unitOfWork.Specializations.Remove(specialization);
            SpecializationList.Remove(specialization);
            unitOfWork.SaveChanges();
        }
    }
}
