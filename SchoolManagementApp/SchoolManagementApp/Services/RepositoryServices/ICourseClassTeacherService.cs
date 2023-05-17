using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.Services.RepositoryServices.Abstractions;
using System.Collections.ObjectModel;

namespace SchoolManagementApp.Services.RepositoryServices
{
    public interface ICourseClassTeacherService : ICollectionService<CourseClassTeacher>
    {
        ObservableCollection<CourseClassTeacher> CourseTeacherList { get; set; }
    }
}
