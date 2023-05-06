using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
