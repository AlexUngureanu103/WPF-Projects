using SchoolManagementApp.Domain.Models;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student GetByUserId(int userId);
    }
}
