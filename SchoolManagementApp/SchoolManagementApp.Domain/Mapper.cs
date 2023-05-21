using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementApp.Domain
{
    public static class Mapper
    {
        public static StudentAbsenceDto CreateStudentAbsenceDto(Student student, int absencesCount)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null)
            {
                return new StudentAbsenceDto();
            }
            return new StudentAbsenceDto
            {
                Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                AbsencesCount = absencesCount,
                Class = student.Class,
                Email = student.User.Email,
                CanBeExmatriculated = absencesCount >= 10
            };
        }

        public static RepeaterStudentDto CreateRepeaterStudentDto(Student student, IEnumerable<CourseType> courses)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null || courses == null || courses.Count() < 3)
                return null;
            string coursesString = string.Empty;
            foreach (var course in courses)
            {
                coursesString += course.Course + ", ";
            }
            return new RepeaterStudentDto
            {
                Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                Class = student.Class,
                Email = student.User.Email,
                Courses = coursesString
            };
        }
    }
}
