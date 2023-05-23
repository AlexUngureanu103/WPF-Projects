using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.ServiceAbstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Services.BusinessLayer.Commands
{
    public class RepeaterStudents
    {
        private readonly IAverageGradeService _averageGradeService;

        public RepeaterStudents(IAverageGradeService averageGradeService)
        {
            _averageGradeService = averageGradeService ?? throw new ArgumentNullException(nameof(averageGradeService));
        }

        public ObservableCollection<RepeaterStudentDto> GetRepeaterStudents(IEnumerable<Student> studentList)
        {
            var studentRepeaterList = new ObservableCollection<RepeaterStudentDto>();

            foreach (Student student in studentList)
            {
                var corrigentCourses = _averageGradeService.GetStudentAverageGrades(student)
                    .Where(c => c.Semester == 0 && c.Average < 5).ToList()
                    .Select(c => c.ClassCourse.CourseType)
                    .ToList();
                var reapeater = Mapper.CreateRepeaterStudentDto(student, corrigentCourses);
                if (reapeater != null)
                {
                    studentRepeaterList.Add(reapeater);
                }
            }

            return studentRepeaterList;
        }
    }
}
