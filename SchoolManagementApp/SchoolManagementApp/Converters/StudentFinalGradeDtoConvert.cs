using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class StudentFinalGradeDtoConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Student student = values[0] as Student;
            CourseClass courseClass = values[1] as CourseClass;
            //AverageGrade FirstSemester = values[2] as AverageGrade;
            //AverageGrade SecondSemester = values[3] as AverageGrade;

            if (values[0] != null && values[1] != null /*&& values[2] != null && values[3] != null*/)
            {
                return new StudentFinalGradeDto()
                {
                    Student = student,
                    CourseClass = courseClass,
                    //FirstSemester = FirstSemester,
                    //SecondSemester = SecondSemester
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            StudentFinalGradeDto studentFinalGradeDto = value as StudentFinalGradeDto;
            object[] result = new object[4] { studentFinalGradeDto.Student, studentFinalGradeDto.CourseClass, studentFinalGradeDto.FirstSemester, studentFinalGradeDto.SecondSemester };
            return result;
        }
    }
}
