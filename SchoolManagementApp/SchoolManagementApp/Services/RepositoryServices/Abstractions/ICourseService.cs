using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ICourseService : ICollectionService<CourseType>
    {
        ObservableCollection<CourseType> CourseList { get; set; }

        bool EntityAlreadyExists(CourseType courseType);

        ObservableCollection<CourseType> GetClassCourses(int classId);
    }
}
