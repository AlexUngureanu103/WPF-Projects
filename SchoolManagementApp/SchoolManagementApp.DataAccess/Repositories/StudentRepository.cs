using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }

        public Student GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
