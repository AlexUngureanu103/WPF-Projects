using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class TeachingMaterialsRepository : RepositoryBase<TeachingMaterial>, ITeachingMaterialsRepository
    {
        public TeachingMaterialsRepository(SchoolManagementDbContext context) : base(context)
        {
        }

        public new IEnumerable<TeachingMaterial> GetAll()
        {
            var teachingMaterials = GetRecords()
                .Include(c => c.CourseClass)
                .Include(c => c.CourseClass.CourseType)
                .Include(c => c.CourseClass.Class.Specialization)
                .Include(c => c.CourseClass.Class.Teacher.User.Person);

            return teachingMaterials;
        }

        public IEnumerable<TeachingMaterial> GetClassTeachingMaterials(int classId)
        {
            var teachingMaterials = GetAll().Where(c => c.CourseClass.ClassId == classId && c.CourseClass.HasCourse);

            return teachingMaterials;
        }

        public IEnumerable<TeachingMaterial> GetCourseClassTeachingMaterials(int courseClassId)
        {
            var teachingMaterials = GetAll().Where(c => c.CourseClassId == courseClassId);

            return teachingMaterials;
        }
    }
}
