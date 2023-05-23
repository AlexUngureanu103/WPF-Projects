using SchoolManagementApp.Domain.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ICourseService : ICollectionService<CourseType>
    {
        ObservableCollection<CourseType> CourseList { get; set; }

        string errorMessage { get; set; }

        bool EntityAlreadyExists(CourseType courseType);

        ObservableCollection<CourseType> GetClassCourses(int classId);
    }
}
