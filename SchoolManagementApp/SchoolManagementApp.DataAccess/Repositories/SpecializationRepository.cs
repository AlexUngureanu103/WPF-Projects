using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
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
