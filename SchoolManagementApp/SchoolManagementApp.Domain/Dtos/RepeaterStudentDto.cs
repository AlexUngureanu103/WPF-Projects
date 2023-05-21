using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.Dtos
{
    public class RepeaterStudentDto
    {
        public Class Class { get; set; }

        public string Email { get; set; }
        
        public string Name { get; set; }

        public string Courses { get; set; }
    }
}
