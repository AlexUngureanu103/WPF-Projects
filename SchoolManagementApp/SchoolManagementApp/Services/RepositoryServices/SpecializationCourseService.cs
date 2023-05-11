using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class SpecializationCourseService : ISpecializationCourseService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<SpecializationCourse> SpecializationCourseList { get; set; }

        private string errorMessage;

        public SpecializationCourseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<SpecializationCourse> GetAll()
        {
            var result = unitOfWork.SpecializationCourse.GetAll();
            foreach (var specializationCourse in result)
            {
                specializationCourse.CourseType = unitOfWork.Courses.GetById(specializationCourse.CourseTypeId);
                specializationCourse.Specialization = unitOfWork.Specializations.GetById(specializationCourse.SpecializationId);
            }

            return new ObservableCollection<SpecializationCourse>(result);
        }

        private bool ValidateSpecializationCourse(SpecializationCourse specializationCourse)
        {
            if (specializationCourse == null)
            {
                errorMessage = "Course cannot be null";
                return false;
            }

            bool isValidCourseId = unitOfWork.Courses.Any(c => c.Id == specializationCourse.CourseTypeId);
            if (!isValidCourseId)
            {
                errorMessage = "Course invalid";
                return false;
            }

            bool isValidSpecializationId = unitOfWork.Specializations.Any(c => c.Id == specializationCourse.SpecializationId);
            if (!isValidSpecializationId)
            {
                errorMessage = "Specialization invalid";
                return false;
            }
            return true;
        }

        public bool EntityAlreadyExists(SpecializationCourse specializationCourse)
        {
            var entity = unitOfWork.SpecializationCourse.GetById(specializationCourse.Id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public void Add(SpecializationCourse specializationCourse)
        {
            if (!ValidateSpecializationCourse(specializationCourse))
            {
                return;
            }

            var entity = SpecializationCourseList.FirstOrDefault(c => c.CourseTypeId == specializationCourse.CourseTypeId && c.SpecializationId == specializationCourse.SpecializationId);
            if(entity != null)
            {
                return;
                specializationCourse.Id = entity.Id;
                unitOfWork.SpecializationCourse.Update(specializationCourse);
            }
            else
            {
                unitOfWork.SpecializationCourse.Add(specializationCourse);
                SpecializationCourseList.Add(specializationCourse);
            }
            unitOfWork.SaveChanges();
        }

        public void Edit(SpecializationCourse specializationCourse)
        {
            SpecializationCourse result = unitOfWork.SpecializationCourse.GetById(specializationCourse.Id);

            if (result == null)
            {
                errorMessage = "Course not found";
                return;
            }
            if (!ValidateSpecializationCourse(specializationCourse))
            {
                return;
            }

            unitOfWork.SpecializationCourse.Update(specializationCourse);
            unitOfWork.SaveChanges();
        }

        public void Remove(SpecializationCourse specializationCourse)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {specializationCourse.Id} Course?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (specializationCourse == null)
            {
                errorMessage = "Course cannot be null";
                return;
            }

            unitOfWork.SpecializationCourse.Remove(specializationCourse);
            SpecializationCourseList.Remove(specializationCourse);
            unitOfWork.SaveChanges();
        }
    }
}
