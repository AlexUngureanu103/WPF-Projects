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

        public CourseClassService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public ObservableCollection<CourseClass> GetAll()
        {
            return new ObservableCollection<CourseClass>(unitOfWork.CourseClasses.GetAll());
        }

        private bool ValidateEntiry(CourseClass entity)
        {
            var notUnique =  CourseClassList.Any(c=>c.ClassId == entity.ClassId && c.CourseTypeId == entity.CourseTypeId );
            if(notUnique)
            {
                errorMessage = "Entity already exists";
                return false;
            }
            return true;
        }

        public void Add(CourseClass entity)
        {
            if (!ValidateEntiry(entity))
                return;

            unitOfWork.CourseClasses.Add(entity);
            CourseClassList.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(CourseClass entity)
        {
            var courseClass = unitOfWork.CourseClasses.GetById(entity.Id);
            if (courseClass == null)
            {
                errorMessage = "CourseClass not found";
                return;
            }
            if (!ValidateEntiry(entity))
                return;

            unitOfWork.CourseClasses.Update(entity);
            unitOfWork.SaveChanges();
        }

        public void Remove(CourseClass entity)
        {
            if (entity == null)
            {
                errorMessage = "CourseClass cannot be null";
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the {entity.Id} CourseClass?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.CourseClasses.Remove(entity);
            CourseClassList.Remove(entity);
            unitOfWork.SaveChanges();
        }
    }
}
