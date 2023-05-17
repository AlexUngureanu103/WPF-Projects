using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class Grade : BaseEntity
    {
        private int valuee;
        [Required]
        [Range(1, 10)]
        public int Value
        {
            get { return valuee; }
            set { valuee = value; NotifyPropertyChanged("Value"); }
        }

        private bool isThesis;
        public bool IsThesis
        {
            get { return isThesis; }
            set { isThesis = value; NotifyPropertyChanged("IsThesis"); }
        }

        private int semester;
        [Required]
        [Range(1, 2)]
        public int Semester
        {
            get { return semester; }
            set { semester = value; NotifyPropertyChanged("Semester"); }
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
        
        private DateTime date;
        [Required]
        public DateTime Date
        {
            get { return date; }
            set { date = value; NotifyPropertyChanged("Date"); }
        }

    }
}
