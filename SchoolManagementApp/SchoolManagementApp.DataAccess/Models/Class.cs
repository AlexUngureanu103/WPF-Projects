using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Models
{
    internal class Class : BaseEntity
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
