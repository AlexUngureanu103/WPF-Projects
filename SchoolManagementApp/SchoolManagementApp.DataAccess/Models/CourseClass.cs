using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class CourseClass : BaseEntity
    {
        [Required]
        public int CourseTypeId { get; set; }

        public CourseType CourseType { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
