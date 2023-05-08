using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class ClassService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Class> ClassList { get; set; }

        private string errorMessage;

        public ClassService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<Class> GetAll()
        {
            return new ObservableCollection<Class>(unitOfWork.Classes.GetAll());
        }

        private bool ValidateClass(Class @class)
        {
            if (@class == null || string.IsNullOrEmpty(@class.Name))
            {
                errorMessage = "Course name cannot be empty";
                return false;
            }

            var hasNameConflicts = unitOfWork.Classes.Any(c => c.Name == @class.Name && c.Id!=@class.Id);
            if (hasNameConflicts)
            {
                errorMessage = $"Class with name: {@class.Name} already exists";
                return false;
            }

            var specialization = unitOfWork.Specializations.GetById(@class.SpecializationId);
            if (specialization == null)
            {
                errorMessage = "Specialization cannot be null";
                return false;
            }

            return true;
        }

        public void Add(Class @class)
        {
            if (!ValidateClass(@class))
                return;

            unitOfWork.Classes.Add(@class);
            ClassList.Add(@class);
            unitOfWork.SaveChanges();
        }

        public void Edit(Class @class)
        {

            Class result = unitOfWork.Classes.GetById(@class.Id);
            if (result == null)
            {
                errorMessage = "Course not found";
                return;
            }

            if (!ValidateClass(@class))
                return;

            unitOfWork.Classes.Update(@class);
            var cl = ClassList.First(c => c.Id == @class.Id);
            cl = @class;
            unitOfWork.SaveChanges();
        }

        public void Remove(Class @class)
        {
            if (@class == null)
            {
                errorMessage = "Course cannot be null";
                return;
            }

            unitOfWork.Classes.Remove(@class);
            ClassList.Remove(@class);
            unitOfWork.SaveChanges();
        }
    }
}
