using SchoolManagementApp.Domain.Models.StudentRelated;

namespace SchoolManagementApp.Domain.Models
{
    public class CourseClassTeacher : BaseEntity
    {
        private int courseClassId;
        public int CourseClassId
        {
            get { return courseClassId; }
            set { courseClassId = value; NotifyPropertyChanged("CourseClassId"); }
        }

        private CourseClass courseClass;
        public CourseClass CourseClass
        {
            get { return courseClass; }
            set { courseClass = value; NotifyPropertyChanged("CourseClass"); }
        }

        private int? teacherId;
        public int? TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; NotifyPropertyChanged("TeacherId"); }
        }

        private Teacher teacher;
        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; NotifyPropertyChanged("Teacher"); }
        }
    }
}
