using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class AbsencesRepository : RepositoryBase<Absences>, IAbsencesRepository
    {
        public AbsencesRepository(SchoolManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<Absences> GetStudentAbsences(int studentId)
        {
            return GetRecords().Where(absence => absence.StudentId == studentId);
        }

        public IEnumerable<Absences> GetStudentAbsences(int studentId, int courseId)
        {
            return GetRecords().Where(absence => absence.StudentId == studentId && absence.CourseTypeId == courseId);
        }
    }
}
