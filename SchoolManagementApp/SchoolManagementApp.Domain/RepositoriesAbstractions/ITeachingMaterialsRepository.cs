using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface ITeachingMaterialsRepository : IRepository<TeachingMaterial>
    {
        IEnumerable<TeachingMaterial> GetCourseClassTeachingMaterials(int courseClassId);
    }
}
