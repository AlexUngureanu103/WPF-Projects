using SchoolManagementApp.DataAccess.Models;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class UserConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Role role = values[0] as Role;
            Person person = values[1] as Person;
            
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new User()
                {
                    RoleId = role.Id,
                    Role = role,
                    Person = person,
                    personId = person.Id,
                    Email = values[2].ToString(),
                    PasswordHash = values[3].ToString()
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            User user = value as User;
            object[] result = new object[6] { user.RoleId, user.Role, user.Person, user.personId, user.Email, user.PasswordHash };

            return result;
        }
    }
}
