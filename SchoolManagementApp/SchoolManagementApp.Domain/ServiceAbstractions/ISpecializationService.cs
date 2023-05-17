using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ISpecializationService : ICollectionService<Specialization>
    {
        ObservableCollection<Specialization> SpecializationList { get; set; }

        Specialization GetById(int id);
    }
}
