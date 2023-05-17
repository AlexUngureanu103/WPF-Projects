using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        public ClassRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
