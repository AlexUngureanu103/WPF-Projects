using SchoolManagementApp.Domain.Models.StudentRelated;

namespace SchoolManagementApp.Domain.Dtos
{
    public class StudentTopDto
    {
        public Class Class { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public double FinalGrade { get; set; }

        public ClassTop Place { get; set; }
    }
}
