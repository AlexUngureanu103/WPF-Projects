using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace SchoolManagementApp.Services.BusinessLayer
{
    internal class ClassService : IClassService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Class> ClassList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public ClassService(UnitOfWork unitOfWork, log4net.ILog logger)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            log = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public ObservableCollection<Class> GetAll()
        {
            var classes = unitOfWork.Classes.GetAll();

            return new ObservableCollection<Class>(classes);
        }

        private bool ValidateClass(Class @class)
        {
            if (@class == null || string.IsNullOrEmpty(@class.Name))
            {
                errorMessage = "Course name cannot be empty";
                log.Error(errorMessage);
                return false;
            }

            var hasNameConflicts = unitOfWork.Classes.Any(c => c.Name == @class.Name && c.Id != @class.Id);
            if (hasNameConflicts)
            {
                errorMessage = $"Class with name: {@class.Name} already exists";
                log.Error(errorMessage);
                return false;
            }
            string pattern = @"^(?:[5-9]|1[0-2])[A-H]$";
            if (!Regex.IsMatch(@class.Name, pattern))
            {
                errorMessage = "Class name must be in format: [5-12] + [A-H]";
                log.Error(errorMessage);
                return false;
            }

            var alreadyExistsClassMaster = unitOfWork.Classes.Any(c => c.TeacherId == @class.TeacherId && c.Id != @class.Id);
            if (alreadyExistsClassMaster)
            {
                errorMessage = "Class master already has a class";
                log.Error(errorMessage);
                return false;
            }

            var specialization = unitOfWork.Specializations.GetById((int)@class.SpecializationId);
            if (specialization == null)
            {
                errorMessage = "Specialization cannot be null";
                log.Error(errorMessage);
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
            log.Info($"Class {@class.Name} added");
            errorMessage = string.Empty;
        }

        public void Edit(Class @class)
        {
            if (@class.TeacherId == null && @class.Teacher != null)
                @class.TeacherId = @class.Teacher.Id;
            Class resultFromDb = unitOfWork.Classes.GetById(@class.Id);
            if (resultFromDb == null)
            {
                errorMessage = "Course not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateClass(@class))
                return;

            //unitOfWork.Classes.Update(@class);
            resultFromDb.Name = @class.Name;
            resultFromDb.SpecializationId = @class.SpecializationId;

            unitOfWork.SaveChanges();
            log.Info($"Class {@class.Name} edited");
            errorMessage = string.Empty;
        }

        public void Remove(Class @class)
        {
            if (@class == null)
            {
                errorMessage = "Course cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Classes.Remove(@class);
            ClassList.Remove(@class);
            unitOfWork.SaveChanges();
            log.Info($"Class {@class.Name} removed");
            errorMessage = string.Empty;
        }

        public Class GetClassByClassMasterId(Teacher teacher)
        {
            var ownClass = unitOfWork.Classes.GetClassByClassMasterId(teacher.Id);

            return ownClass;
        }
    }
}
