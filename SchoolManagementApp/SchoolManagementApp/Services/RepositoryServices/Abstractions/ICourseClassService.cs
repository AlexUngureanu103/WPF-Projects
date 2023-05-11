using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices.Abstractions
{
    public interface ICourseClassService : ICollectionService<CourseClass>
    {
        ObservableCollection<CourseClass> CourseClassList { get; set; }
    }
}
