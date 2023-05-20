using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class TeachingMaterialsService : ITeachingMaterialsService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<TeachingMaterial> TeachingMaterialsList { get; set; }

        private string errorMessage;

        private log4net.ILog log;

        public TeachingMaterialsService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        private bool ValidateTeachingMaterial(TeachingMaterial entity)
        {
            if (entity == null)
            {
                errorMessage = "Teaching Material cannot be null";
                log.Error(errorMessage);
                return false;
            }

            if (string.IsNullOrEmpty(entity.Name))
            {
                errorMessage = "Name cannot be null or empty for a material";
                return false;
            }
            if (string.IsNullOrEmpty(entity.Content))
            {
                errorMessage = "Content cannot be null or empty for a meterial";
                return false;
            }

            var courseClass = unitOfWork.CourseClasses.Any(c => c.Id == entity.CourseClassId /*&& c.HasCourse*/);
            if (!courseClass)
            {
                errorMessage = $"Course class relation with id: {entity.CourseClassId} not found";
                return false;
            }

            return true;
        }

        public void Add(TeachingMaterial entity)
        {
            if (!ValidateTeachingMaterial(entity))
            {
                log.Error(errorMessage);
                return;
            }

            unitOfWork.TeachingMaterials.Add(entity);
            TeachingMaterialsList.Add(entity);
            unitOfWork.SaveChanges();
            log.Info($"Teaching Material with Name {entity.Name} for class {entity.CourseClass.Class.Name} , on couse {entity.CourseClass.CourseType.Course} was added");
        }

        public void Edit(TeachingMaterial entity)
        {
            if (!ValidateTeachingMaterial(entity))
            {
                log.Error(errorMessage);
                return;
            }

            TeachingMaterial resultFromDb = unitOfWork.TeachingMaterials.GetById(entity.Id);

            if (resultFromDb == null)
            {
                errorMessage = $"Teaching material with Id: {entity.Id} not found";
                log.Error(errorMessage);
                return;
            }

            resultFromDb.Content = entity.Content;
            resultFromDb.Name = entity.Name;
            resultFromDb.CourseClass = entity.CourseClass;

            unitOfWork.SaveChanges();
            log.Info($"Teaching Material with id: {entity.Id} was updated to :\nName {entity.Name} for class {entity.CourseClass.Class.Name} , on couse {entity.CourseClass.CourseType.Course}");
        }

        public ObservableCollection<TeachingMaterial> GetAll()
        {
            var teachingMaterials = unitOfWork.TeachingMaterials.GetAll();

            return new ObservableCollection<TeachingMaterial>(teachingMaterials);
        }

        public ObservableCollection<TeachingMaterial> GetCourseClassTeachingMaterials(CourseClass courseClass)
        {
            if (courseClass == null)
            {
                errorMessage = "Course class cannot be null";
                log.Error(errorMessage);
                return new ObservableCollection<TeachingMaterial>();
            }
            var teachingMaterials = unitOfWork.TeachingMaterials.GetCourseClassTeachingMaterials(courseClass.Id);

            return new ObservableCollection<TeachingMaterial>(teachingMaterials);
        }

        public void Remove(TeachingMaterial entity)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {entity.Name} material?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (entity == null)
            {
                errorMessage = "Course cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.TeachingMaterials.Remove(entity);
            TeachingMaterialsList.Remove(entity);
            unitOfWork.SaveChanges();
            log.Info($"Teaching Material with id: {entity.Id} , Name {entity.Name} was deleted");
        }
    }
}
