using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class Absences : BaseEntity
    {
        private DateTime date;
        [Required]
        public DateTime Date
        {
            get { return date; }
            set { date = value; NotifyPropertyChanged("Date"); }
        }

        private int semester;
        [Required]
        [Range(1, 2)]
        public int Semester
        {
            get { return semester; }
            set { semester = value; NotifyPropertyChanged("Semester"); }
        }

        private bool isMotivated;
        [Required]
        public bool IsMotivated
        {
            get { return isMotivated; }
            set { isMotivated = value; NotifyPropertyChanged("IsMotivated"); }
        }

        private int studentId;
        [Required]
        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; NotifyPropertyChanged("StudentId"); }
        }

        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; NotifyPropertyChanged("Student"); }
        }

        private int? courseTypeId;
        [Required]
        public int? CourseTypeId
        {
            get { return courseTypeId; }
            set { courseTypeId = value; NotifyPropertyChanged("CourseTypeId"); }
        }

        private CourseType courseType;
        public CourseType CourseType
        {
            get { return courseType; }
            set { courseType = value; NotifyPropertyChanged("CourseType"); }
        }
    }
}
