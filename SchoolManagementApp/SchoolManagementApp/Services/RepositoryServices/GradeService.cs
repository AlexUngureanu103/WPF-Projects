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

        private readonly log4net.ILog log;

        public GradeService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ObservableCollection<Grade> GetAll()
        {
            return new ObservableCollection<Grade>(unitOfWork.Grades.GetAll());
        }

        public ObservableCollection<Grade> GetStudentGrades(Student student)
        {
            if (student == null)
                return new ObservableCollection<Grade>();
            return new ObservableCollection<Grade>(unitOfWork.Grades.GetStudentGrades(student.Id));
        }

        private bool ValidateGrade(Grade grade)
        {
            if (grade == null)
            {
                errorMessage = "Grade cannot be null";
                log.Error(errorMessage);
                return false;
            }

            if (grade.Value < 1 || grade.Value > 10)
            {
                errorMessage = "Invalid grade value";
                log.Error(errorMessage);
                return false;
            }

            if (grade.Semester < 1 || grade.Semester > 2)
            {
                errorMessage = "Invalid semester";
                log.Error(errorMessage);
                return false;
            }

            var courseType = unitOfWork.Courses.GetById((int)grade.CourseTypeId);
            if (courseType == null)
            {
                errorMessage = "Invalid course";
                log.Error(errorMessage);
                return false;
            }

            var student = unitOfWork.Students.GetById((int)grade.StudentId);
            if (student == null)
            {
                errorMessage = "invalid Student";
                log.Error(errorMessage);
                return false;
            }

            var specialization = student.Class.Specialization;
            var course = grade.CourseType;
            var courseSpecialization = unitOfWork.SpecializationCourse.GetAll().FirstOrDefault(c => c.SpecializationId == specialization.Id && c.CourseTypeId == course.Id);

            if (courseSpecialization == null)
            {
                errorMessage = "Invalid course for this specialization";
                log.Error(errorMessage);
                return false;
            }
            if (courseSpecialization.HasThesis == false)
            {
                grade.IsThesis = false;
                errorMessage = "This course does not have a thesis";
                log.Error(errorMessage);
            }

            if (grade.IsThesis == true)
            {
                var unique = unitOfWork.Grades.GetAll().FirstOrDefault(g => g.StudentId == student.Id && g.CourseTypeId == grade.CourseTypeId && g.IsThesis == true && g.Semester == grade.Semester);

                if (unique != null)
                {
                    errorMessage = "Student already has a thesis for this course";
                    log.Error(errorMessage);
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
            log.Info($"Grade {grade.Id} added");
        }

        public void Edit(Grade grade)
        {
            Grade resultFromDb = unitOfWork.Grades.GetById(grade.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Grade not found";
                log.Error(errorMessage);
                return;
            }
            if (!ValidateGrade(grade))
                return;

            //unitOfWork.Grades.Update(grade);
            resultFromDb.Value = grade.Value;
            resultFromDb.IsThesis = grade.IsThesis;
            resultFromDb.Semester = grade.Semester;
            resultFromDb.CourseTypeId = grade.CourseTypeId;
            resultFromDb.StudentId = grade.StudentId;
            resultFromDb.Date = grade.Date;

            unitOfWork.SaveChanges();
            log.Info($"Grade {grade.Id} edited");
        }

        public void Remove(Grade grade)
        {
            var result = MessageBox.Show($"Are u sure u want to delete the {grade.Id} Grade?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            if (grade == null)
            {
                errorMessage = "Grade cannot be null";
                log.Error(errorMessage);
                return;
            }

            unitOfWork.Grades.Remove(grade);
            GradeList.Remove(grade);
            unitOfWork.SaveChanges();
            log.Info($"Grade {grade.Id} removed");
        }
    }
}
