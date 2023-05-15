using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
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
    }
}
