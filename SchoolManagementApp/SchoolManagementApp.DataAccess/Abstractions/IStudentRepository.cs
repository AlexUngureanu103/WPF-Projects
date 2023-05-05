using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface IStudentRepository : IRepository<Student>
    {
        Student GetByUserId(int userId);
    }
}
