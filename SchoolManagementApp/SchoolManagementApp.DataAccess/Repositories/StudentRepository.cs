﻿using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
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

        public IEnumerable<Student> GetStudentByClassId(int classId)
        {
            var students = GetAll()
                .Where(c => c.ClassId == classId);

            return students;
        }
    }
}
