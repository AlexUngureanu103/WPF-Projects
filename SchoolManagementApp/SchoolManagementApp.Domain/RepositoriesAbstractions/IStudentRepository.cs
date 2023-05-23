using SchoolManagementApp.Domain.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByUserId(int userId);

        IEnumerable<Student> GetStudentByClassId(int classId);
    }
}
