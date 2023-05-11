using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class CourseClassConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Class @class = values[0] as Class;
            CourseType course = values[1] as CourseType;
            if (values[0] != null && values[1] != null && values[2] !=null)
            {
                return new CourseClass()
                {
                    ClassId = @class.Id,
                    Class = @class,
                    CourseTypeId = course.Id,
                    CourseType = course,
                    HasCourse = (bool)values[2]
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            CourseClass courseClass = value as CourseClass;
            object[] result = new object[5] { courseClass.ClassId, courseClass.Class, courseClass.CourseTypeId, courseClass.CourseType , courseClass.HasCourse };
            return result;
        }
    }
}
