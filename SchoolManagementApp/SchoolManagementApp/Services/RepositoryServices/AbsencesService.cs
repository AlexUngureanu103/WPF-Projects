using SchoolManagementApp.DataAccess;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.ServiceAbstractions;
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

        private readonly log4net.ILog log;

        public AbsencesService(UnitOfWork unitOfWork, log4net.ILog log)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        private bool ValidateAbsence(Absences absence)
        {
            if (absence == null)
            {
                errorMessage = "Grade cannot be null";
                log.Error(errorMessage);
                return false;
            }

            if (absence.Semester < 1 || absence.Semester > 2)
            {
                errorMessage = "Invalid semester";
                log.Error(errorMessage);
                return false;
            }

            var courseType = unitOfWork.Courses.GetById((int)absence.CourseTypeId);
            if (courseType == null)
            {
                errorMessage = "Invalid course";
                log.Error(errorMessage);
                return false;
            }

            var student = unitOfWork.Students.GetById((int)absence.StudentId);
            if (student == null)
            {
                errorMessage = "invalid Student";
                log.Error(errorMessage);
                return false;
            }

            var specialization = student.Class.Specialization;
            var course = absence.CourseType;
            var courseSpecialization = unitOfWork.SpecializationCourse.GetAll().FirstOrDefault(c => c.SpecializationId == specialization.Id && c.CourseTypeId == course.Id);

            if (courseSpecialization == null)
            {
                errorMessage = "Invalid course for this specialization";
                log.Error(errorMessage);
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
            log.Info($"Absence {entity.Id} added");
        }

        public void Edit(Absences entity)
        {
            Absences resultFromDb = unitOfWork.Absences.GetById(entity.Id);

            if (resultFromDb == null)
            {
                errorMessage = "Grade not found";
                log.Error(errorMessage);
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
            log.Info($"Absence {entity.Id} updated");
        }

        public void MotivateAbsence(Absences entity)
        {
            Absences resultFromDb = unitOfWork.Absences.GetById(entity.Id);
            if (resultFromDb == null)
            {
                errorMessage = "Grade not found";
                log.Error(errorMessage);
                return;
            }
            if (!ValidateAbsence(entity))
                return;
            if (resultFromDb.IsMotivated)
            {
                log.Info($"Absence with id: {entity.Id} is already motivated ");
                return;
            }
            entity.IsMotivated = true;
            //resultFromDb.IsMotivated = entity.IsMotivated;
            //unitOfWork.SaveChanges();
            unitOfWork.Absences.MotivateAbsence(entity.Id);
            log.Info($"Absence with id: {entity.Id} motivated ");
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
                log.Error(errorMessage);
                return;
            }

            var result = MessageBox.Show($"Are u sure u want to delete the {entity.Id} Absence?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No) return;

            unitOfWork.Absences.Remove(entity);
            AbsenceList.Remove(entity);
            unitOfWork.SaveChanges();
            log.Info($"Absence {entity.Id} deleted");
        }

        public ObservableCollection<Absences> GetStudentAbsences(Student student)
        {
            if (student == null)
                return new ObservableCollection<Absences>();
            return new ObservableCollection<Absences>(unitOfWork.Absences.GetStudentAbsences(student.Id));
        }

        public ObservableCollection<Absences> GetStudentAbsences(Student student, CourseType course)
        {
            if (student == null || course == null)
                return new ObservableCollection<Absences>();
            return new ObservableCollection<Absences>(unitOfWork.Absences.GetStudentAbsences(student.Id, course.Id));
        }
    }
}
