using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class StudentConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            User user = values[0] as User;
            Class @class = values[1] as Class;

            if (values[0] != null && values[1] != null)
            {
                return new Student()
                {
                    UserId = user.Id,
                    User = user,
                    ClassId = @class.Id,
                    Class = @class
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Student student = value as Student;
            object[] result = new object[4] { student.UserId, student.User, student.ClassId, student.Class };

            return result;
        }
    }
}
