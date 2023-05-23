using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.BusinessLayer
{
    internal class SpecializationCourseService : ISpecializationCourseService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<SpecializationCourse> SpecializationCourseList { get; set; }

        public string errorMessage { get; set; }

        private readonly log4net.ILog log;

        public SpecializationCourseService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
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
                log.Error(errorMessage);
                return false;
            }

            bool isValidCourseId = unitOfWork.Courses.Any(c => c.Id == specializationCourse.CourseTypeId);
            if (!isValidCourseId)
            {
                errorMessage = $"Course: {specializationCourse.CourseTypeId} invalid";
                log.Error(errorMessage);
                return false;
            }

            bool isValidSpecializationId = unitOfWork.Specializations.Any(c => c.Id == specializationCourse.SpecializationId);
            if (!isValidSpecializationId)
            {
                errorMessage = $"Specialization: {specializationCourse.SpecializationId} invalid";
                log.Error(errorMessage);
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
            if (entity != null)
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
            log.Info($"Course {specializationCourse.Id} added");
            errorMessage = string.Empty;
        }

        public void Edit(SpecializationCourse specializationCourse)
        {
            SpecializationCourse resultFromDb = unitOfWork.SpecializationCourse.GetById(specializationCourse.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Course not found";
                log.Error(errorMessage);
                return;
            }
            if (!ValidateSpecializationCourse(specializationCourse))
            {
                return;
            }

            //unitOfWork.SpecializationCourse.Update(specializationCourse);
            resultFromDb.SpecializationId = specializationCourse.SpecializationId;
            resultFromDb.CourseTypeId = specializationCourse.CourseTypeId;
            resultFromDb.HasThesis = specializationCourse.HasThesis;

            unitOfWork.SaveChanges();
            log.Info($"Course {specializationCourse.Id} edited");
            errorMessage = string.Empty;
        }

        public void Remove(SpecializationCourse specializationCourse)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {specializationCourse.Id} Course?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (specializationCourse == null)
            {
                errorMessage = "Course cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.SpecializationCourse.Remove(specializationCourse);
            SpecializationCourseList.Remove(specializationCourse);
            unitOfWork.SaveChanges();
            log.Info($"Course {specializationCourse.Id} removed");
            errorMessage = string.Empty;
        }
    }
}
