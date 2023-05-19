using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;

namespace SchoolManagementApp.Domain.Dtos
{
    public class StudentFinalGradeDto
    {
        public Student Student { get; set; }

        public CourseClass CourseClass { get; set; }

        public AverageGrade FirstSemester { get; set; }

        public AverageGrade SecondSemester { get; set; }
    }
}
