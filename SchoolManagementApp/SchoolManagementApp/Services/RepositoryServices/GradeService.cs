using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class GradeService : IGradeService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Grade> GradeList { get; set; }

        public ObservableCollection<Grade> CurrentStudentGrades { get; set; }

        private string errorMessage;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ObservableCollection<Grade> GetAll()
        {
            return new ObservableCollection<Grade>(unitOfWork.Grades.GetAll());
        }

        public ObservableCollection<Grade> GetStudentGrades(Student student)
        {
            if(student == null)
                return new ObservableCollection<Grade>();
            return new ObservableCollection<Grade>(unitOfWork.Grades.GetStudentGrades(student.Id));
        }

        private bool ValidateGrade(Grade grade)
        {
            if (grade == null)
            {
                errorMessage = "Grade cannot be null";
                return false;
            }

            if (grade.Value < 1 || grade.Value > 10)
            {
                errorMessage = "Invalid grade value";
                return false;
            }

            if (grade.Semester < 1 || grade.Semester > 2)
            {
                errorMessage = "Invalid semester";
                return false;
            }

            var courseType = unitOfWork.Courses.GetById((int)grade.CourseTypeId);
            if (courseType == null)
            {
                errorMessage = "Invalid course";
                return false;
            }

            var student = unitOfWork.Students.GetById((int)grade.StudentId);
            if (student == null)
            {
                errorMessage = "invalid Student";
                return false;
            }

            var specialization = student.Class.Specialization;
            var course = grade.CourseType;
            var courseSpecialization = unitOfWork.SpecializationCourse.GetAll().FirstOrDefault(c => c.SpecializationId == specialization.Id && c.CourseTypeId == course.Id);

            if (courseSpecialization == null)
            {
                errorMessage = "Invalid course for this specialization";
                return false;
            }
            if (courseSpecialization.HasThesis == false)
            {
                grade.IsThesis = false;
                errorMessage = "This course does not have a thesis";
            }

            if (grade.IsThesis == true)
            {
                var unique = unitOfWork.Grades.GetAll().FirstOrDefault(g => g.StudentId == student.Id && g.CourseTypeId == grade.CourseTypeId && g.IsThesis == true && g.Semester == grade.Semester);

                if (unique != null)
                {
                    errorMessage = "Student already has a thesis for this course";
                    return false;
                }
            }

            return true;
        }

        public void Add(Grade grade)
        {
            if (!ValidateGrade(grade))
                return;

            unitOfWork.Grades.Add(grade);
            GradeList.Add(grade);
            unitOfWork.SaveChanges();
        }

        public void Edit(Grade grade)
        {
            Grade result = unitOfWork.Grades.GetById(grade.Id);

            if (result == null)
            {
                errorMessage = "Grade not found";
                return;
            }
            if (!ValidateGrade(grade))
                return;

            unitOfWork.Grades.Update(grade);
            unitOfWork.SaveChanges();
        }

        public void Remove(Grade grade)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {grade.Id} Grade?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (grade == null)
            {
                errorMessage = "Grade cannot be null";
                return;
            }

            unitOfWork.Grades.Remove(grade);
            unitOfWork.SaveChanges();
        }
    }
}
