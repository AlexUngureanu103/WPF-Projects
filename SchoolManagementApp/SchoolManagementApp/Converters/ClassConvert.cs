using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class ClassConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Specialization specialization = values[1] as Specialization;
            if (specialization == null)
                specialization = new Specialization();
            if (values[0] != null && values[1] != null)
            {
                return new Class()
                {
                    Name = values[0].ToString(),
                    SpecializationId = specialization.Id,
                    Specialization = specialization
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Class @class = value as Class;
            object[] result = new object[2] { @class.Name, @class.SpecializationId };
            return result;
        }
    }
}
