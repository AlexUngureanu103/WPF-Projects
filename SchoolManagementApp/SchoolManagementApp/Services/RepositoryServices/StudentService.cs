using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class StudentService
    {
        private readonly UnitOfWork unitOfWork;

        public StudentService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Student Add(Student student)
        {
            if (student == null) return null;

            unitOfWork.Students.Add(student);
            unitOfWork.SaveChanges();
            return student;
        }
        
        public bool Edit(Student student)
        {
            if (student == null || string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName) || string.IsNullOrEmpty(student.Address))
            {
                return false;
            }

            Student Student = unitOfWork.Students.GetById(student.Id);

            if (Student == null) return false;

            unitOfWork.Students.Update(student);
            unitOfWork.SaveChanges();
            return true;
        }

        public Student Remove(Student student)
        {
            if (student == null) return null;

            unitOfWork.Students.Remove(student);
            unitOfWork.SaveChanges();
            return student;
        }
    }
}
