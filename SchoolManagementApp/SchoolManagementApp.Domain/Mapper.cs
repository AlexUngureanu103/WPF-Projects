using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;

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
    }
}
