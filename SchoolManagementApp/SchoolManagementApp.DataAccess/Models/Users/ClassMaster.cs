using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.Users
{
    public class ClassMaster : BaseEntity
    {
        [Required]
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        [Required]
        public int ClassId { get; set; }

        public Class Class { get; set; }
    }
}
