using SchoolManagementApp.DataAccess.Models;
using System.Collections.Generic;

namespace SchoolManagementApp.DataAccess.Abstractions
{
    internal interface ICourseRepository
    {
        IEnumerable<CourseType> GetAll();

        CourseType Get(int id);

        void Add(CourseType course);

        void Update(CourseType course);

        void Delete(CourseType course);
    }
}
