using SchoolManagementApp.DataAccess.Abstractions;
using SchoolManagementApp.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(SchoolManagementDbContext dbContext) : base(dbContext)
        {
        }


        public new IEnumerable<Student> GetAll()
        {
            var students = GetRecords()
                .Include(c => c.Class)
                .Include(c => c.User)
                .Include(c => c.User.Person)
                .ToList();

            return students;
        }
        public Student GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
