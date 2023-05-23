using SchoolManagementApp.Domain.Models;

namespace SchoolManagementApp.Domain.Dtos
{
    public class StudentFinalGrade
    {
        public Student Student { get; set; }

        public double FinalGrade { get; set; }
    }
}
