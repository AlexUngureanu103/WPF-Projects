using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Data.Entity;

namespace SchoolManagementApp.DataAccess
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(string connectionString) : base(connectionString)
        {
        }

        public SchoolManagementDbContext() : base("Server=localhost;Database=SchoolManagement;User Id=AlexUngureanu;Password=123456;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<CourseType> Courses { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Absences> Absences { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<CourseClass> CourseClasses { get; set; }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<CourseClassTeacher> CourseClassTeachers { get; set; }

        public DbSet<SpecializationCourse> SpecializationCourses { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<AverageGrade> AverageGrades { get; set; }

        public DbSet<TeachingMaterial> TeachingMaterials { get; set; }
    }
}
