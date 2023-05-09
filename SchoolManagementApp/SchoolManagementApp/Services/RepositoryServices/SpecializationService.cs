using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    public class SpecializationService /*: ICollectionService<Specialization>*/
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Specialization> SpecializationList { get; set; }

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

        public Specialization Add(Specialization specialization)
        {
            if (specialization == null || string.IsNullOrEmpty(specialization.Name)) return null;

            var hasEmailConflicts = unitOfWork.Specializations.Any(c => c.Name == specialization.Name);
            if (hasEmailConflicts) return null;

            unitOfWork.Specializations.Add(specialization);
            SpecializationList.Add(specialization);
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
            SpecializationList.Remove(specialization);
            unitOfWork.SaveChanges();
            return specialization;
        }
    }
}
