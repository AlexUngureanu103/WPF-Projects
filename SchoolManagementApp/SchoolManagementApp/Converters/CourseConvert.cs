using SchoolManagementApp.DataAccess.Models;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    class CourseConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null)
            {
                return new CourseType()
                {
                    Course = values[0].ToString(),
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            CourseType course = value as CourseType;
            object[] result = new object[1] { course.Course };
            return result;
        }
    }
}
