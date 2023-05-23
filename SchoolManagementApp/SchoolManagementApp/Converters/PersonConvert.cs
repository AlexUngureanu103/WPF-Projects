using SchoolManagementApp.Domain.Models;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class PersonConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new Person()
                {
                    FirstName = values[0].ToString(),
                    LastName = values[1].ToString(),
                    DateOfBirth = (DateTime)values[2],
                    Address = values[3].ToString()
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Person person = value as Person;
            object[] result = new object[4] { person.FirstName, person.LastName, person.DateOfBirth, person.Address };
            return result;
        }
    }
}
