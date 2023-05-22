using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface IAverageGradeService
    {
        ObservableCollection<AverageGrade> AverageGrades { get; set; }

        string errorMessage { get; set; }

        ObservableCollection<AverageGrade> GetAll();

        ObservableCollection<AverageGrade> GetStudentAverageGrades(Student student);

        ObservableCollection<AverageGrade> GetClassAverageGrades(Class @class);

        void CalculateStudentAverageGrade(StudentGradeAverageDto student);

        void CalculateStudentFinalGrade(StudentFinalGradeDto student);
    }
}
