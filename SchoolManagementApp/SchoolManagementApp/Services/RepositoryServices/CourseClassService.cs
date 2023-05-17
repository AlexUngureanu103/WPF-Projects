using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class CourseClassService : ICourseClassService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<CourseClass> CourseClassList { get; set; }

        private string errorMessage;

        private readonly log4net.ILog log;

        public CourseClassService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }
        public ObservableCollection<CourseClass> GetAll()
        {
            return new ObservableCollection<CourseClass>(unitOfWork.CourseClasses.GetAll());
        }

        private bool ValidateEntity(CourseClass entity)
        {
            var clas = unitOfWork.Classes.GetById(entity.ClassId);
            if (clas == null)
            {
                errorMessage = "Invalid class";
                log.Error(errorMessage);
                return false;
            }

            var course = unitOfWork.Courses.GetById(entity.CourseTypeId);
            if (course == null)
            {
                errorMessage = "Invalid course";
                log.Error(errorMessage);
                return false;
            }
            return true;
        }

        public void Add(CourseClass entity)
        {
            if (!ValidateEntity(entity))
                return;
            var notUnique = CourseClassList.Any(c => c.ClassId == entity.ClassId && c.CourseTypeId == entity.CourseTypeId);
            if (notUnique)
            {
                errorMessage = "Entity already exists";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.CourseClasses.Add(entity);
            CourseClassList.Add(entity);
            unitOfWork.SaveChanges();
            log.Info($"CourseClass {entity.Id} added successfully");
        }

        public void Edit(CourseClass entity)
        {
            CourseClass resultFromDb = unitOfWork.CourseClasses.GetById(entity.Id);
            if (resultFromDb == null)
            {
                errorMessage = "CourseClass not found";
                log.Error(errorMessage);
                return;
            }
            if (!ValidateEntity(entity))
                return;

            //unitOfWork.CourseClasses.Update(entity);
            resultFromDb.CourseTypeId = entity.CourseTypeId;
            resultFromDb.ClassId = entity.ClassId;
            resultFromDb.HasCourse = entity.HasCourse;
            
            unitOfWork.SaveChanges();
            log.Info($"CourseClass {entity.Id} edited successfully");
        }

        public void Remove(CourseClass entity)
        {
            if (entity == null)
            {
                errorMessage = "CourseClass cannot be null";
                log.Error(errorMessage);
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the {entity.Id} CourseClass?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.CourseClasses.Remove(entity);
            CourseClassList.Remove(entity);
            unitOfWork.SaveChanges();
            log.Info($"CourseClass {entity.Id} removed successfully");
        }
    }
}
