using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagementApp.DataAccess.Models.StudentRelated;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class GradeService
    {
        private readonly UnitOfWork unitOfWork;

        public GradeService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public Grade Add(Grade grade)
        {
            if (grade == null) return null;
            //validate Id's
            
            //var hasNameConflicts = unitOfWork.Grades.Any(c => c. == grade.Course);
            //if (hasNameConflicts) return null;

            unitOfWork.Grades.Add(grade);
            unitOfWork.SaveChanges();
            return grade;
        }

        public bool Edit(Grade grade)
        {
            if (grade == null )
            {
                return false;
            }

            Grade result = unitOfWork.Grades.GetById(grade.Id);

            if (result == null) return false;

            unitOfWork.Grades.Update(grade);
            unitOfWork.SaveChanges();
            return true;
        }

        public Grade Remove(Grade grade)
        {
            if (grade == null) return null;

            unitOfWork.Grades.Remove(grade);
            unitOfWork.SaveChanges();
            return grade;
        }
    }
}
