﻿using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System;
using System.Windows.Data;

namespace SchoolManagementApp.Converters
{
    internal class ClassConvert : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Specialization specialization = values[1] as Specialization;
            Teacher teacher = values[2] as Teacher;

            if (values[0] != null && values[1] != null && values[2] != null)
            {
                return new Class()
                {
                    Name = values[0].ToString(),
                    SpecializationId = specialization.Id,
                    Specialization = specialization,
                    TeacherId = teacher.Id,
                    Teacher = teacher
                };
            }
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Class @class = value as Class;
            object[] result = new object[5] { @class.Name, @class.SpecializationId, @class.Specialization, @class.TeacherId, @class.Teacher };
            return result;
        }
    }
}
