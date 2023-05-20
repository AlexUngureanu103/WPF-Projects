using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ITeachingMaterialsService : ICollectionService<TeachingMaterial>
    {
        ObservableCollection<TeachingMaterial> TeachingMaterialsList { get; set; }

        ObservableCollection<TeachingMaterial> GetCourseClassTeachingMaterials(CourseClass courseClass);

        ObservableCollection<TeachingMaterial> GetClassTeachingMaterials(Class @class);
    }
}
