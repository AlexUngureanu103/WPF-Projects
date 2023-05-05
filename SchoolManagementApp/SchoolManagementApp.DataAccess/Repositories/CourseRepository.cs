using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class CourseRepository : RepositoryBase<CourseType>, ICourseRepository
    {
        public CourseRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
