using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    internal interface ICourseService : ICollectionService<CourseType>
    {
        bool EntityAlreadyExists(CourseType courseType);
    }
}
