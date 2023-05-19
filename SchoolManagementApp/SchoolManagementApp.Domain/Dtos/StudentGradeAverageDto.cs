using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.Dtos

{
    public class StudentGradeAverageDto
    {
        public Student Student { get; set; }

        public CourseClass CourseClass { get; set; }

        public List<Grade> Grades { get; set; }

        public int Semester { get; set; }
    }
}
