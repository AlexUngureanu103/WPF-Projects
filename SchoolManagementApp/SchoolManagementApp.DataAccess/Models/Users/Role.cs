using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models
{
    internal class Role : BaseEntity
    {
        [Required]
        public string AssignedRole { get; set; }
    }
}
