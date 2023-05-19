using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class AverageGradeService : IAverageGradeService
    {
        public ObservableCollection<AverageGrade> AverageGrades { get; set; }

        private readonly UnitOfWork unitOfWork;

        private string errorMessage;

        private readonly log4net.ILog log;

        public AverageGradeService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public ObservableCollection<AverageGrade> GetAll()
        {
            var averageGrades = unitOfWork.AverageGrade.GetAll();

            return new ObservableCollection<AverageGrade>(averageGrades);
        }

        public ObservableCollection<AverageGrade> GetClassAverageGrades(Class @class)
        {
            var classGrades = unitOfWork.AverageGrade.GetClassAverageGrades(@class.Id);

            return new ObservableCollection<AverageGrade>(classGrades);
        }

        public ObservableCollection<AverageGrade> GetStudentAverageGrades(Student student)
        {
            var studentAverageGrades = unitOfWork.AverageGrade.GetStudentAverageGrades(student.Id);

            return new ObservableCollection<AverageGrade>(studentAverageGrades);
        }

        public void CalculateStudentAverageGrade(StudentGradeAverageDto studentAverageGrades)
        {
            if (!validateAverageGrade(studentAverageGrades))
            {
                log.Error(errorMessage);
                return;
            }

            double average = CalculateAverate(studentAverageGrades);
            var resultFromDb = unitOfWork.AverageGrade.GetStudentCourseAverage(studentAverageGrades.CourseClass.Id, studentAverageGrades.Student.Id, studentAverageGrades.Semester);
            if (resultFromDb == null)
            {
                var averageGrade = new AverageGrade
                {
                    Semester = studentAverageGrades.Semester,
                    StudentId = studentAverageGrades.Student.Id,
                    CourseClasstId = studentAverageGrades.CourseClass.Id,
                    Average = average
                };
                unitOfWork.AverageGrade.Add(averageGrade);
                averageGrade.Student = studentAverageGrades.Student;
                averageGrade.ClassCourse = studentAverageGrades.CourseClass;
            }
            else
            {
                resultFromDb.Average = average;
            }

            unitOfWork.SaveChanges();
            log.Info($"Student : {studentAverageGrades.Student.User.Person.FirstName}  {studentAverageGrades.Student.User.Person.LastName} on course {studentAverageGrades.CourseClass.CourseType.Course} has Average of  {average} on Semester: {studentAverageGrades.Semester}");
        }

        private double CalculateAverate(StudentGradeAverageDto studentGradeAverageDTO)
        {
            var courseGrades = studentGradeAverageDTO.Grades.Where(c => c.CourseTypeId == studentGradeAverageDTO.CourseClass.CourseTypeId && c.Semester == studentGradeAverageDTO.Semester).ToList();
            double average = 0;

            Grade thesis = courseGrades.FirstOrDefault(c => c.IsThesis);
            List<Grade> nonThesis = courseGrades.Where(c => !c.IsThesis).ToList();

            if (thesis != null)
            {
                average = nonThesis.Sum(c => c.Value) / nonThesis.Count * 3 + thesis.Value;
                return average / 4;
            }

            return nonThesis.Sum(c => c.Value) / nonThesis.Count;
        }

        private bool validateAverageGrade(StudentGradeAverageDto studentGradeAverageDTO)
        {
            if (studentGradeAverageDTO == null)
            {
                errorMessage = $"studentGradeAverage was null";
                return false;
            }
            var validStudent = unitOfWork.Students.Any(c => c.Id == studentGradeAverageDTO.Student.Id);
            if (!validStudent)
            {
                errorMessage = $"Student with Id: {studentGradeAverageDTO.Student.Id} not found";
                return false;
            }

            var courseClass = unitOfWork.CourseClasses.GetById(studentGradeAverageDTO.CourseClass.Id);
            if (courseClass == null)
            {
                errorMessage = $"Course class with Id: {studentGradeAverageDTO.CourseClass.Id} not found";
                return false;
            }
            else
            {
                if (!courseClass.HasCourse)
                {
                    errorMessage = $"Course class relation with Id: {courseClass.Id} has no course";
                    return false;
                }
                //else
                //{
                //    if(courseClass.ClassId != studentGradeAverageDTO.CourseClass.cl)
                //}
            }

            // test specialization
            var specCourse = unitOfWork.SpecializationCourse.GetAll().FirstOrDefault(c => c.SpecializationId == studentGradeAverageDTO.CourseClass.Class.SpecializationId && c.CourseTypeId == courseClass.CourseTypeId);

            if (specCourse == null)
            {
                errorMessage = $"Specailization Course relation not found!";
                return false;
            }
            var courseGrades = studentGradeAverageDTO.Grades.Where(c => c.CourseTypeId == studentGradeAverageDTO.CourseClass.CourseTypeId && c.Semester == studentGradeAverageDTO.Semester).ToList();

            var hasThesis = courseGrades.Any(c => c.IsThesis);

            if (hasThesis != specCourse.HasThesis)
            {
                errorMessage = $"Student: {studentGradeAverageDTO.Student.User.Person.FirstName}  {studentGradeAverageDTO.Student.User.Person.LastName} doesn't have a thesis for course: {studentGradeAverageDTO.CourseClass.CourseType.Course} yet";
                return false;
            }

            if (hasThesis)
            {
                if (courseGrades.Count() < 4)
                {
                    errorMessage = $"Student: {studentGradeAverageDTO.Student.User.Person.FirstName}  {studentGradeAverageDTO.Student.User.Person.LastName} doesn't have enough grades for course: {studentGradeAverageDTO.CourseClass.CourseType.Course} yet";
                    return false;
                }
            }
            else if (courseGrades.Count() < 3)
            {
                errorMessage = $"Student: {studentGradeAverageDTO.Student.User.Person.FirstName}  {studentGradeAverageDTO.Student.User.Person.LastName} doesn't have enough grades for course: {studentGradeAverageDTO.CourseClass.CourseType.Course} yet";
                return false;
            }

            return true;
        }
    }
}
