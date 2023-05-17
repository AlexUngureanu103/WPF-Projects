using SchoolManagementApp.DataAccess.Models;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class TeacherConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            User user = values[0] as User;

            if (values[0] != null)
            {
                return new Teacher()
                {
                    UserId = user.Id,
                    User = user,
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Teacher teacher = value as Teacher;
            object[] result = new object[2] { teacher.UserId, teacher.User };
            return result;
        }
    }
}
