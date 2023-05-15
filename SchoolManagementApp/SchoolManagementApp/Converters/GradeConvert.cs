using SchoolManagementApp.DataAccess.Models;
using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class GradeConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Student student = values[0] as Student;

            CourseType course = values[1] as CourseType;

            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null)
            {
                return new Grade()
                {
                    Student = student,
                    StudentId = student.Id,
                    CourseType = course,
                    CourseTypeId = course.Id,
                    Value = int.Parse(values[2].ToString()),
                    IsThesis = (bool)values[3],
                    Semester = int.Parse(values[4].ToString()),
                    Date = DateTime.Now
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Grade grade = value as Grade;
            object[] result = new object[8] { grade.Student, grade.StudentId, grade.CourseType, grade.CourseTypeId, grade.Value, grade.IsThesis, grade.Semester, grade.Date };
            return result;
        }
    }
}
