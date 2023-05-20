using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.Domain.Models.StudentRelated
{
    public class TeachingMaterial : BaseEntity
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { content = value; NotifyPropertyChanged("Content"); }
        }

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

        private int semester;
        [Range(1,2)]
        public int Semester
        {
            get { return semester; }
            set { semester = value; NotifyPropertyChanged("Semester"); }
        }
    }
}
