using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class SpecializationCourseConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Specialization specialization = values[0] as Specialization;
            if (specialization == null)
                specialization = new Specialization();

            CourseType course = values[1] as CourseType;
            if (course == null)
                course = new CourseType();
            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return new SpecializationCourse()
                {
                    SpecializationId = specialization.Id,
                    Specialization = specialization,
                    CourseType = course,
                    CourseTypeId = course.Id,
                    HasThesis = (bool)values[2]
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            SpecializationCourse specializationCourse = value as SpecializationCourse;
            object[] result = new object[3] { specializationCourse.Specialization, specializationCourse.CourseType, specializationCourse.HasThesis };
            return result;
        }
    }
}
