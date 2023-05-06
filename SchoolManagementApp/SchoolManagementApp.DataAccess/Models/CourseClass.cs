using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.StudentRelated
{
    public class CourseClass : BaseEntity
    {
        private int courseTypeId;
        [Required]
        public int CourseTypeId
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

        private int classId;
        [Required]
        public int ClassId
        {
            get { return classId; }
            set { classId = value; NotifyPropertyChanged("ClassId"); }
        }

        private Class classs;
        public Class Class
        {
            get { return classs; }
            set { classs = value; NotifyPropertyChanged("Class"); }
        }
    }
}
