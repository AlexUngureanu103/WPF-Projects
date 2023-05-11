using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class CourseClassRepository : RepositoryBase<CourseClass>, ICourseClassRepository
    {
        public CourseClassRepository(SchoolManagementDbContext dbcontext) : base(dbcontext)
        {
        }
    }
}
