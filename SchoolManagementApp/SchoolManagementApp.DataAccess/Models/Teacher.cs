using System;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Models
{
    internal class Teacher
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public List<CourseClass> TeachingClasses { get; set; }
    }
}
