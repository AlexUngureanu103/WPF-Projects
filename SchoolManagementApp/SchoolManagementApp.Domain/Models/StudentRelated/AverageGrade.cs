namespace SchoolManagementApp.Domain.Models.StudentRelated
{
    public class AverageGrade : BaseEntity
    {
        private int studentId;
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

        private int courseClassId;
        public int CourseClasstId
        {
            get { return courseClassId; }
            set { courseClassId = value; NotifyPropertyChanged("CourseClasstId"); }
        }

        private CourseClass classCourse;
        public CourseClass ClassCourse
        {
            get { return classCourse; }
            set { classCourse = value; NotifyPropertyChanged("ClassCourse"); }
        }

        private double average;
        public double Average
        {
            get { return average; }
            set { average = value; NotifyPropertyChanged("Average"); }
        }

        private int semester;
        public int Semester
        {
            get { return semester; }
            set { semester = value; NotifyPropertyChanged("Semester"); }
        }
    }
}
