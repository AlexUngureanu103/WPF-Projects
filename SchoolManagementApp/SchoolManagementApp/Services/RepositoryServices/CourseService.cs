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

        public CourseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
                return;
            }

            var hasNameConflicts = unitOfWork.Courses.Any(c => c.Course == course.Course);
            if (hasNameConflicts)
            {
                errorMessage = "Course with this name already exists";
                return;
            }

            unitOfWork.Courses.Add(course);
            CourseList.Add(course);
            unitOfWork.SaveChanges();
        }

        public void Edit(CourseType course)
        {
            if (course == null || string.IsNullOrEmpty(course.Course))
            {
                errorMessage = "Course name cannot be empty";
                return;
            }

            CourseType resultFromDb = unitOfWork.Courses.GetById(course.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Course not found";
                return;
            }

            //unitOfWork.Courses.Update(course);
            resultFromDb.Course = course.Course;
            
            unitOfWork.SaveChanges();
        }

        public void Remove(CourseType course)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {course.Course} Course?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (course == null)
            {
                errorMessage = "Course cannot be null";
                return;
            }

            unitOfWork.Courses.Remove(course);
            CourseList.Remove(course);
            unitOfWork.SaveChanges();
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
