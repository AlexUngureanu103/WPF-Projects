using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    public class Role : BaseEntity
    {
        [Required]
        public string AssignedRole { get; set; }
    }
}
