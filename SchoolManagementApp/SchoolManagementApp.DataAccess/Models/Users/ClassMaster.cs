using SchoolManagementApp.DataAccess.Models.StudentRelated;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementApp.DataAccess.Models.Users
{
    public class ClassMaster : BaseEntity
    {
        private int teacherId;
        [Required]
        public int TeacherId
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
