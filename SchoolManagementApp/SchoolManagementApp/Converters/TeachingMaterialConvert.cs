using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class TeachingMaterialConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CourseClass courseClass = values[0] as CourseClass;

            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new TeachingMaterial()
                {
                    Name = values[1].ToString(),
                    Content = values[2].ToString(),
                    CourseClassId = courseClass.Id,
                    CourseClass = courseClass,
                    Semester = (int)values[3]

                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            TeachingMaterial TeachingMaterial = value as TeachingMaterial;
            object[] result = new object[5] { TeachingMaterial.Name, TeachingMaterial.Content, TeachingMaterial.CourseClassId, TeachingMaterial.CourseClass, TeachingMaterial.Semester };
            return result;
        }
    }
}
