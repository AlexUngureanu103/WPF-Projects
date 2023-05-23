using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.BusinessLayer
{
    public class SpecializationService : ISpecializationService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Specialization> SpecializationList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public SpecializationService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
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
            {
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Specializations.Add(specialization);
            SpecializationList.Add(specialization);
            unitOfWork.SaveChanges();
            log.Info($"Specialization with name {specialization.Name} was created");
            errorMessage = string.Empty;
        }

        public void Edit(Specialization specialization)
        {
            Specialization specializationFromDb = unitOfWork.Specializations.GetById(specialization.Id);

            if (specializationFromDb == null)
            {
                errorMessage = $"Specialization: {specialization.Id} not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateSpecialization(specialization))
            {
                log.Error(errorMessage);
                return;
            }

            //unitOfWork.Specializations.Update(specialization);
            specializationFromDb.Name = specialization.Name;

            unitOfWork.SaveChanges();
            log.Info($"Specialization {specialization.Name} edited");
            errorMessage = string.Empty;
        }

        public void Remove(Specialization specialization)
        {
            if (specialization == null)
            {
                errorMessage = "Specialization cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Specializations.Remove(specialization);
            SpecializationList.Remove(specialization);
            unitOfWork.SaveChanges();
            log.Info($"Specilization {specialization.Name} deleted");
            errorMessage = string.Empty;
        }
    }
}
