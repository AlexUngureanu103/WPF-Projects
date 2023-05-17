using SchoolManagementApp.Domain.Models.StudentRelated;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {
        Specialization GetByName(string name);
    }
}
