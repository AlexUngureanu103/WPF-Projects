using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    internal interface ISpecializationService : ICollectionService<Specialization>
    {
        Specialization GetById(int id);
    }
}
