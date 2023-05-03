using SchoolManagementApp.DataAccess.Models;
using System.Data.Entity;

namespace SchoolManagementApp.DataAccess
{
    internal class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(string connectionString) : base(connectionString)
        {
        }

        public SchoolManagementDbContext() : base("Server=localhost;Database=SchoolManagement;User Id=AlexUngureanu;Password=123456;") { }

        public DbSet<Role> Roles { get; set; }

        public DbSet<CourseType> Courses { get; set; }
    }
}
