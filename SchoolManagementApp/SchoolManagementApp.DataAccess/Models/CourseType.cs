using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class CourseType : BaseEntity
    {
        [Required]
        public string Course { get; set; }
    }
}
