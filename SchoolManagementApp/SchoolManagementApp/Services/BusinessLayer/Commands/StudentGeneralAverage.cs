using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.BusinessLayer.Commands
{
    public class StudentGeneralAverage
    {
        private IAverageGradeService _averageGradeService;

        private ICourseService _courseService;

        public StudentGeneralAverage(IAverageGradeService averageGradeService, ICourseService courseService)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
            _courseService = courseService ?? throw new ArgumentNullException(nameof(courseService));
        }

        public void DisplayGeneralAverage(Student student)
        {
            var CourseList = _courseService.GetClassCourses(student.Class.Id);
            var studentsFinalGrades = _averageGradeService.GetStudentAverageGrades(student).Where(c => c.Semester == 0);

            if (studentsFinalGrades == null)
                return;
            if (studentsFinalGrades.Count() != CourseList.Count)
            {
                MessageBox.Show("Please finalize every subject grades.", "Error");
                return;
            }
            else
            {
                double final = studentsFinalGrades.Sum(c => c.Average) / studentsFinalGrades.Count();
                MessageBox.Show($"Student : {student.User.Person.FirstName}  {student.User.Person.LastName} has the General Average: {final}");
            }
        }
    }
}
