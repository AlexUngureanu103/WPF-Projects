using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface ISpecializationRepository : IRepository<Specialization>
    {
        Specialization GetByName(string name);
    }
}
