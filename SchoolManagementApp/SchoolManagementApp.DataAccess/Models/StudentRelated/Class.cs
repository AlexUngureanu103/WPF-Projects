using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    internal class Class : BaseEntity
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        [NotMapped]
        public int StudentCount { get; set; }
    }
}
