using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Domain.ServiceAbstractions
{
    public interface ICourseClassService : ICollectionService<CourseClass>
    {
        ObservableCollection<CourseClass> CourseClassList { get; set; }

        string errorMessage { get; }
    }
}
