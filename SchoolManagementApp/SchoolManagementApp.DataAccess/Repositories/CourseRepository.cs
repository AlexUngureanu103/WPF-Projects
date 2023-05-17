using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class CourseRepository : RepositoryBase<CourseType>, ICourseRepository
    {
        public CourseRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
