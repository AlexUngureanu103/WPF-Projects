using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.Generic;
using System.Data.Entity;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseClassRepository : RepositoryBase<CourseClass>, ICourseClassRepository
    {
        public CourseClassRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }

        public new IEnumerable<CourseClass> GetAll()
        {
            var courseClasses = GetRecords()
                .Include(c => c.CourseType)
                .Include(c => c.Class)
                .Include(c => c.Class.Specialization);

            return courseClasses;
        }
    }
}
