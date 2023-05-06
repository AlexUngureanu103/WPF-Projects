using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class ClassService
    {
        private readonly UnitOfWork unitOfWork;

        public ClassService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Class Add(Class @class)
        {
            if (@class == null) return null;

            var hasNameConflicts = unitOfWork.Classes.Any(c => c.Name == @class.Name);
            if (hasNameConflicts) return null;

            unitOfWork.Classes.Add(@class);
            unitOfWork.SaveChanges();
            return @class;
        }

        public bool Edit(Class @class)
        {
            if (@class == null || string.IsNullOrEmpty(@class.Name))
            {
                return false;
            }

            Class result = unitOfWork.Classes.GetById(@class.Id);

            if (result == null) return false;

            unitOfWork.Classes.Update(@class);
            unitOfWork.SaveChanges();
            return true;
        }

        public Class Remove(Class @class)
        {
            if (@class == null) return null;

            unitOfWork.Classes.Remove(@class);
            unitOfWork.SaveChanges();
            return @class;
        }
    }
}
