using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ISpecializationService : ICollectionService<Specialization>
    {
        ObservableCollection<Specialization> SpecializationList { get; set; }

        Specialization GetById(int id);
    }
}
