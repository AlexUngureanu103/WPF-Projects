using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Class : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int SpecializationId { get; set; }

        public Specialization Specialization { get; set; }

        public List<Student> Students { get; set; }

        [NotMapped]
        public int StudentCount { get; set; }
    }
}
