using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class CourseClassTeacherConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CourseClass courseClass = values[0] as CourseClass;
            Teacher teacher = values[1] as Teacher;

            if (values[0] != null && values[1] != null)
            {
                return new CourseClassTeacher()
                {
                    TeacherId = teacher.Id,
                    Teacher = teacher,
                    CourseClassId = courseClass.Id,
                    CourseClass = courseClass
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            CourseClassTeacher courseClassTeacher = value as CourseClassTeacher;
            object[] result = new object[4] { courseClassTeacher.TeacherId, courseClassTeacher.Teacher, courseClassTeacher.CourseClassId, courseClassTeacher.CourseClass };
            return result;
        }
    }
}
