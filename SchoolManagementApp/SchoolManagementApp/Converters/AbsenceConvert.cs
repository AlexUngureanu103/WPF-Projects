using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class AbsenceConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Student student = values[0] as Student;

            CourseType course = values[1] as CourseType;

            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new Absences()
                {
                    Student = student,
                    StudentId = student.Id,
                    CourseType = course,
                    CourseTypeId = course.Id,
                    Semester = int.Parse(values[3].ToString()),
                    IsMotivated = (bool)values[2],
                    Date = DateTime.Now
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Absences absence = value as Absences;
            object[] result = new object[7] { absence.Student, absence.StudentId, absence.CourseType, absence.CourseTypeId, absence.Semester, absence.IsMotivated, absence.Date };
            return result;
        }
    }
}
