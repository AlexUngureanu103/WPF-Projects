using SchoolManagementApp.Domain.Dtos;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.Models.StudentRelated;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchoolManagementApp.Domain
{
    public static class Mapper
    {
        public static StudentAbsenceDto CreateStudentAbsenceDto(Student student, int absencesCount)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null)
            {
                return new StudentAbsenceDto();
            }
            return new StudentAbsenceDto
            {
                Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                AbsencesCount = absencesCount,
                Class = student.Class,
                Email = student.User.Email,
                CanBeExmatriculated = absencesCount >= 10
            };
        }

        public static RepeaterStudentDto CreateRepeaterStudentDto(Student student, IEnumerable<CourseType> courses)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null || courses == null || courses.Count() < 3)
                return null;
            string coursesString = string.Empty;
            foreach (var course in courses)
            {
                coursesString += course.Course + ", ";
            }
            return new RepeaterStudentDto
            {
                Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                Class = student.Class,
                Email = student.User.Email,
                Courses = coursesString
            };
        }

        public static ObservableCollection<StudentTopDto> CreateStudentsTop(IEnumerable<Student> students, IEnumerable<AverageGrade> finalGrades, int expectedCourses)
        {
            if (students == null || finalGrades == null)
                return new ObservableCollection<StudentTopDto>();

            var trueFinalGrades = finalGrades
                .Where(c => c.Semester == 0 && c.Average >= 5)
                .OrderByDescending(c => c.Average);


            var averageGradeDict = new Dictionary<double, List<Student>>();
            foreach (var student in students)
            {
                if (student == null || student.User == null || student.Class == null || student.User.Person == null)
                {
                    continue;
                }

                var studentFinalGrades = trueFinalGrades.Where(f => f.StudentId == student.Id).ToList();
                if (studentFinalGrades.Count() != expectedCourses)
                {
                    continue;
                }
                var finalGrade = studentFinalGrades.Sum(c => c.Average) / studentFinalGrades.Count();
                if (finalGrade == null)
                {
                    continue;
                }

                if (!averageGradeDict.ContainsKey(finalGrade))
                {
                    averageGradeDict[finalGrade] = new List<Student>();
                }
                averageGradeDict[finalGrade].Add(student);
            }

            int place = 1;
            var result = new ObservableCollection<StudentTopDto>();
            foreach (var kvp in averageGradeDict.OrderByDescending(kvp => kvp.Key))
            {
                var studentsWithSameAverage = kvp.Value;
                foreach (var student in studentsWithSameAverage)
                {
                    if (place <= 4)
                    {
                        result.Add(new StudentTopDto
                        {
                            Class = student.Class,
                            Email = student.User.Email,
                            Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                            FinalGrade = kvp.Key,
                            Place = (ClassTop)place
                        });
                    }
                    else
                    {
                        result.Add(new StudentTopDto
                        {
                            Class = student.Class,
                            Email = student.User.Email,
                            Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                            FinalGrade = kvp.Key,
                            Place = ClassTop.None
                        });
                    }
                }

                place ++;
            }

            return result;
        }

        public static StudentTopDto CreateStudentTopDto(Student student, AverageGrade finalGrade, ClassTop place)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null || finalGrade == null)
            {
                return null;
            }

            return new StudentTopDto
            {
                Class = student.Class,
                Email = student.User.Email,
                Name = student.User.Person.FirstName + ' ' + student.User.Person.LastName,
                FinalGrade = finalGrade.Average,
                Place = place
            };
        }

        public static StudentFinalGrade ToStudentFinalGrade(Student student, IEnumerable<AverageGrade> studentsGrades)
        {
            if (student == null || student.User == null || student.Class == null || student.User.Person == null || studentsGrades == null)
            {
                return null;
            }

            var studentGrades = studentsGrades.Where(c => c.StudentId == student.Id && c.Semester == 0);

            var finalGrade = studentGrades.Sum(c => c.Average) / studentGrades.Count();

            return new StudentFinalGrade
            {
                Student = student,
                FinalGrade = finalGrade
            };
        }
    }
}
