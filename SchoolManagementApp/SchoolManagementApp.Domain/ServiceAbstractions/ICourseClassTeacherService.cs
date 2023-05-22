using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ICourseClassTeacherService : ICollectionService<CourseClassTeacher>
    {
        ObservableCollection<CourseClassTeacher> CourseTeacherList { get; set; }

        string errorMessage { get; set; }

        ObservableCollection<CourseClassTeacher> GetTeachingClasses(int teacherId);
    }
}
