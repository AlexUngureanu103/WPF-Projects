using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByUserId(int userId);
    }
}
