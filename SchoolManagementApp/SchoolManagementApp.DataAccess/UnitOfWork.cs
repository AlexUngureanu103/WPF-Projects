using SchoolManagementApp.DataAccess.Abstractions;
using System;
using System.Data.Entity.Validation;

namespace SchoolManagementApp.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolManagementDbContext _dbContext;

        public IStudentRepository Students { get; }

        public IUserRepository Users { get; }

        public ISpecializationRepository Specializations { get; }

        public IGradeRepository Grades { get; }

        public IClassRepository Classes { get; }

        public IRoleRepository Roles { get; }

        public ICourseRepository Courses { get; }

        public ISpecializationCourseRepository SpecializationCourse { get; }

        public IPersonRepository Persons { get; }

        public ITeacherRepository Teachers { get; }

        public ICourseClassRepository CourseClasses { get; }

        private readonly log4net.ILog log;

        public UnitOfWork(SchoolManagementDbContext dbContext,
            IStudentRepository studentRepository,
            IUserRepository userRepository,
            ISpecializationRepository specializationRepository,
            IGradeRepository gradeRepository,
            IClassRepository classRepository,
            IRoleRepository roleRepository,
            ICourseRepository courseRepository,
            ISpecializationCourseRepository specializationCourseRepository,
            IPersonRepository personRepository,
            ITeacherRepository teacherRepository,
            ICourseClassRepository courseClassRepository,
            log4net.ILog log
            )
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.Students = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            this.Users = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.Specializations = specializationRepository ?? throw new ArgumentNullException(nameof(specializationRepository));
            this.Grades = gradeRepository ?? throw new ArgumentNullException(nameof(gradeRepository));
            this.Classes = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
            this.Roles = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.Courses = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            this.SpecializationCourse = specializationCourseRepository ?? throw new ArgumentNullException(nameof(specializationCourseRepository));
            this.Persons = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            this.Teachers = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
            this.CourseClasses = courseClassRepository ?? throw new ArgumentNullException(nameof(courseClassRepository));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Iterate over the validation errors
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        log.Error($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
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
