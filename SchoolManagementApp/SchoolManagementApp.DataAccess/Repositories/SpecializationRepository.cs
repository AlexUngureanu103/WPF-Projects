using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class SpecializationRepository : RepositoryBase<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }

        public Specialization GetByName(string name)
        {
            return GetRecords().FirstOrDefault(spec => spec.Name == name);
        }
    }
}
