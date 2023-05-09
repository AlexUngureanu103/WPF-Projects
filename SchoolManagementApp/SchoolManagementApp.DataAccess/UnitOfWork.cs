using SchoolManagementApp.DataAccess.Repositories;
using System;

namespace SchoolManagementApp.DataAccess
{
    public class UnitOfWork
    {
        private readonly SchoolManagementDbContext _dbContext;

        public StudentRepository Students { get; }

        public UserRepository Users { get; }

        public SpecializationRepository Specializations { get; }

        public GradeRepository Grades { get; }

        public ClassRepository Classes { get; }

        public RoleRepository Roles { get; }

        public CourseRepository Courses { get; }

        public SpecializationCourseRepository SpecializationCourse { get; }

        public PersonRepository Persons { get; }

        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public UnitOfWork(SchoolManagementDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Students = new StudentRepository(_dbContext);
            Users = new UserRepository(_dbContext);
            Specializations = new SpecializationRepository(_dbContext);
            Grades = new GradeRepository(_dbContext);
            Classes = new ClassRepository(_dbContext);
            Roles = new RoleRepository(_dbContext);
            Courses = new CourseRepository(_dbContext);
            SpecializationCourse = new SpecializationCourseRepository(_dbContext);
            Persons = new PersonRepository(_dbContext);
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
                log.Error(exception.Message, exception);
            }
        }
    }
}
