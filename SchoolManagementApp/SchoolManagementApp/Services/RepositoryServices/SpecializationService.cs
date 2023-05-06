using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class SpecializationService
    {
        private readonly UnitOfWork unitOfWork;

        public SpecializationService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Specialization Add(Specialization specialization)
        {
            if (specialization == null) return null;

            var hasEmailConflicts = unitOfWork.Specializations.Any(c => c.Name == specialization.Name);
            if (hasEmailConflicts) return null;

            unitOfWork.Specializations.Add(specialization);
            unitOfWork.SaveChanges();
            return specialization;
        }

        public bool Edit(Specialization specialization)
        {
            if (specialization == null || string.IsNullOrEmpty(specialization.Name))
            {
                return false;
            }

            Specialization Spec = unitOfWork.Specializations.GetById(specialization.Id);

            if (Spec == null) return false;

            unitOfWork.Specializations.Update(specialization);
            unitOfWork.SaveChanges();
            return true;
        }

        public Specialization Remove(Specialization specialization)
        {
            if (specialization == null) return null;

            unitOfWork.Specializations.Remove(specialization);
            unitOfWork.SaveChanges();
            return specialization;
        }
    }
}
