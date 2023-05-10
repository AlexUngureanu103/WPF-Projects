using SchoolManagementApp.DataAccess.Models;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    internal interface ISpecializationCourseService : ICollectionService<SpecializationCourse>
    {
        bool EntityAlreadyExists(SpecializationCourse specializationCourse);
    }
}
