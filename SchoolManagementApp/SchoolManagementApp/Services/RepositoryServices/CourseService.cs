using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using System;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class CourseService
    {
        private readonly UnitOfWork unitOfWork;

        public CourseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public CourseType Add(CourseType course)
        {
            if (course == null) return null;

            var hasNameConflicts = unitOfWork.Courses.Any(c => c.Course == course.Course);
            if (hasNameConflicts) return null;

            unitOfWork.Courses.Add(course);
            unitOfWork.SaveChanges();
            return course;
        }

        public bool Edit(CourseType course)
        {
            if (course == null || string.IsNullOrEmpty(course.Course))
            {
                return false;
            }

            CourseType result = unitOfWork.Courses.GetById(course.Id);

            if (result == null) return false;

            unitOfWork.Courses.Update(course);
            unitOfWork.SaveChanges();
            return true;
        }

        public CourseType Remove(CourseType course)
        {
            if (course == null) return null;

            unitOfWork.Courses.Remove(course);
            unitOfWork.SaveChanges();
            return course;
        }
    }
}
