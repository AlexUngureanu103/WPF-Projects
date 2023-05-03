using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    internal class CourseType : BaseEntity
    {
        [Required]
        public string Course { get; set; }
    }
}
