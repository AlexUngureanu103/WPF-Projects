using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.DataAccess.Models.Users;
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

        public DbSet<Class> Classes { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Absences> Absences { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<ClassMaster> ClassMasters { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CourseClass> CourseClasses { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<SpecializationCourse> SpecializationCourses { get; set; }
    }
}
