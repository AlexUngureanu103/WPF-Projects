using SchoolManagementApp.Domain.Models;

namespace SchoolManagementApp.Domain.RepositoriesAbstractions
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Teacher GetTeacherByUserId(int userId);
    }
}
