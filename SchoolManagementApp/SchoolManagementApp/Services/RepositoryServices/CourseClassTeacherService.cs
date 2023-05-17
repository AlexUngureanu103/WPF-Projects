using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class CourseClassTeacherService : ICourseClassTeacherService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<CourseClassTeacher> CourseTeacherList { get; set; }

        public string errorMessage;

        private readonly log4net.ILog log;

        public CourseClassTeacherService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }
        public ObservableCollection<CourseClassTeacher> GetAll()
        {
            var courseClassTeacher = unitOfWork.CourseClassTeachers.GetAll();

            return new ObservableCollection<CourseClassTeacher>(courseClassTeacher);
        }

        private bool ValidateCourseClassTeacher(CourseClassTeacher entity)
        {
            var validCourseClassId = unitOfWork.CourseClasses.Any(c => c.Id == entity.CourseClassId);
            if (!validCourseClassId)
            {
                errorMessage = $"Invalid Course class id {entity.CourseClassId}";
                return false;
            }

            var validTeacherId = unitOfWork.Teachers.Any(c => c.Id == entity.TeacherId);
            if (!validTeacherId)
            {
                errorMessage = $"Invalid teacher id: {entity.TeacherId}";
                return false;
            }

            var sameEntityExists = unitOfWork.CourseClassTeachers.Any(c => c.CourseClassId == entity.CourseClassId && c.TeacherId == entity.TeacherId && c.Id != entity.Id);
            if (sameEntityExists)
            {
                errorMessage = $"Referrence :Teacher Id {entity.TeacherId} , CourseClass Id {entity.CourseClassId} already exists";
                return false;
            }
            return true;
        }

        public void Add(CourseClassTeacher entity)
        {
            if (!ValidateCourseClassTeacher(entity))
            {
                log.Error(errorMessage);
                return;
            }

            unitOfWork.CourseClassTeachers.Add(entity);
            CourseTeacherList.Add(entity);
            unitOfWork.SaveChanges();
            log.Info($"Course {entity.CourseClass.CourseType.Course} on class {entity.CourseClass.Class.Name} is lectured by {entity.Teacher.User.Email} {entity.Teacher.User.Person.FirstName} {entity.Teacher.User.Person.LastName} was added");
        }

        public void Edit(CourseClassTeacher entity)
        {
            CourseClassTeacher resultFromDb = unitOfWork.CourseClassTeachers.GetById(entity.Id);
            if (resultFromDb == null)
            {
                errorMessage = "Course Class Teacher relation not found";
                log.Error(errorMessage);
                return;
            }

            if (!ValidateCourseClassTeacher(entity))
            {
                log.Error(errorMessage);
                return;
            }

            resultFromDb.TeacherId = entity.TeacherId;
            resultFromDb.CourseClassId = entity.CourseClassId;

            unitOfWork.SaveChanges();
            log.Info($"Course Class Teacher with Id {entity.Id} edited");
            log.Info($"Course {entity.CourseClass.CourseType.Course} on class {entity.CourseClass.Class.Name} is lectured by {entity.Teacher.User.Email} {entity.Teacher.User.Person.FirstName} {entity.Teacher.User.Person.LastName}");
        }

        public void Remove(CourseClassTeacher entity)
        {
            if (entity == null)
            {
                errorMessage = "Course Class Teacher relation cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.CourseClassTeachers.Remove(entity);
            CourseTeacherList.Remove(entity);
            unitOfWork.SaveChanges();
            log.Info($"Course Class Teacher with Id {entity.Id} deleted");
        }
    }
}
