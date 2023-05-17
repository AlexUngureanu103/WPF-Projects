using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class CourseService : ICourseService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<CourseType> CourseList { get; set; }

        private string errorMessage;

        private readonly log4net.ILog log;

        public CourseService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ObservableCollection<CourseType> GetAll()
        {
            return new ObservableCollection<CourseType>(unitOfWork.Courses.GetAll());
        }

        public bool EntityAlreadyExists(CourseType courseType)
        {
            var entity = unitOfWork.Courses.GetById(courseType.Id);
            if (entity == null)
            {
                return false;
            }
            return true;
        }

        public void Add(CourseType course)
        {
            if (course == null || string.IsNullOrEmpty(course.Course))
            {
                errorMessage = "Course cannot be null";
                log.Error(errorMessage);
                return;
            }

            var hasNameConflicts = unitOfWork.Courses.Any(c => c.Course == course.Course);
            if (hasNameConflicts)
            {
                errorMessage = "Course with this name already exists";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Courses.Add(course);
            CourseList.Add(course);
            unitOfWork.SaveChanges();
            log.Info($"Course {course.Course} added successfully");
        }

        public void Edit(CourseType course)
        {
            if (course == null || string.IsNullOrEmpty(course.Course))
            {
                errorMessage = "Course name cannot be empty";
                log.Error(errorMessage);
                return;
            }

            CourseType resultFromDb = unitOfWork.Courses.GetById(course.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Course not found";
                log.Error(errorMessage);
                return;
            }

            //unitOfWork.Courses.Update(course);
            resultFromDb.Course = course.Course;
            
            unitOfWork.SaveChanges();
            log.Info($"Course {course.Course} edited successfully");
        }

        public void Remove(CourseType course)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {course.Course} Course?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (course == null)
            {
                errorMessage = "Course cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Courses.Remove(course);
            CourseList.Remove(course);
            unitOfWork.SaveChanges();
            log.Info($"Course {course.Course} deleted successfully");
        }

        public ObservableCollection<CourseType> GetClassCourses(int classId)
        {
            var resultFromDb = unitOfWork.Courses.GetAll();

            var courseClass = unitOfWork.CourseClasses.GetAll();

            var courses = courseClass
                .Where(c => c.ClassId == classId && c.HasCourse == true)
                .Select(c => c.CourseType);

            return new ObservableCollection<CourseType>(courses);
        }
    }
}
