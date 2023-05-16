using SchoolManagementApp.DataAccess;
using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolManagementApp.Services.RepositoryServices
{
    internal class AbsencesService : IAbsencesService
    {
        private readonly UnitOfWork unitOfWork;

        public ObservableCollection<Absences> AbsenceList { get; set; }

        private string errorMessage;

        public AbsencesService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        private bool ValidateAbsence(Absences absence)
        {
            if (absence == null)
            {
                errorMessage = "Grade cannot be null";
                return false;
            }

            if (absence.Semester < 1 || absence.Semester > 2)
            {
                errorMessage = "Invalid semester";
                return false;
            }

            var courseType = unitOfWork.Courses.GetById((int)absence.CourseTypeId);
            if (courseType == null)
            {
                errorMessage = "Invalid course";
                return false;
            }

            var student = unitOfWork.Students.GetById((int)absence.StudentId);
            if (student == null)
            {
                errorMessage = "invalid Student";
                return false;
            }

            var specialization = student.Class.Specialization;
            var course = absence.CourseType;
            var courseSpecialization = unitOfWork.SpecializationCourse.GetAll().FirstOrDefault(c => c.SpecializationId == specialization.Id && c.CourseTypeId == course.Id);

            if (courseSpecialization == null)
            {
                errorMessage = "Invalid course for this specialization";
                return false;
            }

            return true;
        }

        public void Add(Absences entity)
        {
            if (!ValidateAbsence(entity))
                return;

            unitOfWork.Absences.Add(entity);
            AbsenceList.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Edit(Absences entity)
        {
            Absences resultFromDb = unitOfWork.Absences.GetById(entity.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Grade not found";
                return;
            }
            if (!ValidateAbsence(entity))
                return;

            //unitOfWork.Absences.Update(entity);
            resultFromDb.Date = entity.Date;
            resultFromDb.Semester = entity.Semester;
            resultFromDb.IsMotivated = entity.IsMotivated;
            resultFromDb.StudentId = entity.StudentId;
            resultFromDb.CourseTypeId = entity.CourseTypeId;
            
            unitOfWork.SaveChanges();
        }

        public ObservableCollection<Absences> GetAll()
        {
            return new ObservableCollection<Absences>(unitOfWork.Absences.GetAll());
        }

        public void Remove(Absences entity)
        {
            if (entity == null)
            {
                errorMessage = "Grade cannot be null";
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the {entity.Id} Absence?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Absences.Remove(entity);
            AbsenceList.Remove(entity);
            unitOfWork.SaveChanges();
        }

        public ObservableCollection<Absences> GetStudentAbsences(Student student)
        {
            if (student == null)
                return new ObservableCollection<Absences>();
            return new ObservableCollection<Absences>(unitOfWork.Absences.GetStudentAbsences(student.Id));
        }
    }
}
