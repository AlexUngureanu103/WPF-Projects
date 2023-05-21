using Microsoft.Data.SqlClient;
using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data;
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

        public void MotivateAbsence(int absenceId)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("MotivateAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramPersonId = new SqlParameter("@absenceId", absenceId);
                SqlParameter paramIsMotivated = new SqlParameter("@isMotivated", true);

                cmd.Parameters.Add(paramPersonId);
                cmd.Parameters.Add(paramIsMotivated);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
