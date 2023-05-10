using SchoolManagementApp.DataAccess.Models;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ISpecializationCourseService : ICollectionService<SpecializationCourse>
    {
        ObservableCollection<SpecializationCourse> SpecializationCourseList { get; set; }

        bool EntityAlreadyExists(SpecializationCourse specializationCourse);
    }
}
