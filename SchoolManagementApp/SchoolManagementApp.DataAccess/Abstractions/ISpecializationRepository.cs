using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface ISpecializationRepository : IRepository<Specialization>
    {
        Specialization GetByName(string name);
    }
}
