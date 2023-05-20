using SchoolManagementApp.Domain.Models.StudentRelated;

namespace SchoolManagementApp.Domain.Dtos
{
    public class StudentAbsenceDto
    {
        public Class Class { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public int AbsencesCount { get; set; }

        public bool CanBeExmatriculated { get; set; }
    }
}
