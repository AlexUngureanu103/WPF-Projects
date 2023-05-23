using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Collections.Generic;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class StudentGradeAverageDtoConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Student student = values[0] as Student;
            CourseClass courseClass = values[1] as CourseClass;
            List<Grade> grades = values[2] as List<Grade>;
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null)
            {
                return new StudentGradeAverageDto()
                {
                    Student = student,
                    CourseClass = courseClass,
                    Grades = grades,
                    Semester = (int)values[3]
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            StudentGradeAverageDto studentAverageGradeDto = value as StudentGradeAverageDto;
            object[] result = new object[4] { studentAverageGradeDto.Student, studentAverageGradeDto.CourseClass, studentAverageGradeDto.Grades, studentAverageGradeDto.Semester };
            return result;
        }
    }
}
